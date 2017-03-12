using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YOYO.AspNetCore.Owin.Helper;


namespace YOYO.AspNetCore.Owin
{
    internal class FormData : IFormData
    {
        private readonly List<IPostedFile> _files = new List<IPostedFile>();
        private readonly Dictionary<string, string> _values = new Dictionary<string, string>();

        public FormData() {
            IsValid = true;
        }

        public IList<IPostedFile> Files {
            get { return _files; }
        }

        public bool IsValid { get; private set; }

        public string this[string name] {
            get {
                string value;
                return _values.TryGetValue(name, out value) ? value : null;
            }
            private set { _values[name] = value; }
        }

        public IDictionary<string, string> Values {
            get { return _values; }
        }

        private static readonly Regex CharsetRegex = new Regex(@"charset=(""?)(\S+)\1", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static readonly Regex ContentDispositionFileRegex = new Regex(@"^Content-Disposition:\s+file;\s*filename=""(.+?)""",
                                                                              RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static readonly Regex ContentDispositionFormDataRegex =
            new Regex(@"^Content-Disposition:\s+form-data;\s*name=""(.+?)""(;\s*filename=""(.+?)"")?",
                      RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static readonly Regex ContentTypeFileRegex = new Regex(@"^Content-Type:\s+(.+)",
                                                                       RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static readonly Regex ContentTypeFormDataRegex =
            new Regex(@"^Content-Type:\s+((multipart/mixed;\s*boundary=(""?)(\w+)\3)|((?!multipart/mixed).+))\s*$",
                      RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static readonly char[] UrlSplitTokens = { '\n', '&' };

        public static string GetMultipartContentType(string boundary) {
            return string.Format(@"multipart/form-data;boundary=""{0}""", boundary);
        }

        public static string GetUrlEncodedContentType() {
            return "application/x-www-form-urlencoded";
        }

        public static Task<FormData> ParseMultipart(Stream stream, string boundary) {
            if (stream == null) {
                throw new ArgumentNullException("stream");
            }
            if (boundary == null) {
                throw new ArgumentNullException("boundary");
            }
            if (boundary.Length == 0) {
                throw new ArgumentException("Boundary cannot be empty", "boundary");
            }
            var form = new FormData();

            boundary = "--" + boundary;
            var boundaryBytes = Encoding.UTF8.GetBytes("\r\n" + boundary);

            string currentLine = stream.ReadLine(Encoding.UTF8);
            if (currentLine != boundary) {
                form.IsValid = false;
                return OwinConstants.TaskHelper.Completed(form);
            }
            while (true) {
                currentLine = stream.ReadLine(Encoding.UTF8);
                // parse ContentDisposition line
                var match = ContentDispositionFormDataRegex.Match(currentLine);
                if (!match.Success) {
                    form.IsValid = false;
                    return OwinConstants.TaskHelper.Completed(form);
                }
                string fieldName = match.Groups[1].Value;
                string fileName = match.Groups[2].Success ? match.Groups[3].Value : null;

                if (fileName != null) {
                    if (!ParseMultipartFile(stream, form, fieldName, fileName, boundaryBytes)) {
                        form.IsValid = false;
                        return OwinConstants.TaskHelper.Completed(form);
                    }
                }
                else {
                    if (!ParseMultipartField(stream, form, fieldName, boundaryBytes)) {
                        form.IsValid = false;
                        return OwinConstants.TaskHelper.Completed(form);
                    }
                }

                // check end or next
                currentLine = stream.ReadLine(Encoding.UTF8);
                // --boundary-- end
                if (currentLine == "--") {
                    break;
                }
                // --boundary between
                if (currentLine != string.Empty) {
                    form.IsValid = false;
                    return OwinConstants.TaskHelper.Completed(form);
                }
            }
            return OwinConstants.TaskHelper.Completed(form);
        }

        /// <summary>
        /// Builds a FormData from the specified input stream, 
        /// which is assumed to be in x-www-form-urlencoded format.
        /// </summary>
        /// <param name="stream">the input stream</param>
        /// <returns>a populated FormData object</returns>
        public static Task<FormData> ParseUrlEncoded(Stream stream) {
            var form = new FormData();
            string input = stream.ReadAll();
            var pairs = input.Split(UrlSplitTokens, StringSplitOptions.RemoveEmptyEntries);
            foreach (var pair in pairs) {
                var nameValue = pair.Split('=');
                form[nameValue[0]] = UrlHelper.Decode(nameValue[1]);
            }
            return OwinConstants.TaskHelper.Completed(form);
        }

        private static bool ParseMultipartField(Stream stream, FormData form, string fieldName, byte[] boundaryBytes) {
            string contentType = null;
            string headerLine;
            Match match;
            while ((headerLine = stream.ReadLine(Encoding.UTF8)) != string.Empty) {
                // parse 'Content-" headers
                match = ContentTypeFormDataRegex.Match(headerLine);
                if (match.Success) {
                    // nested: Content-Type: multipart/mixed; boundary=BbC04y
                    contentType = match.Groups[1].Value.Trim();
                    if (match.Groups[2].Success) {
                        string fileBoundary = match.Groups[4].Value;
                        byte[] fileBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + fileBoundary);
                        byte[] temp;
                        if (!stream.ReadTo(fileBoundaryBytes, out temp)) {
                            return false;
                        }
                        if (stream.ReadLine(Encoding.UTF8) != string.Empty) {
                            return false;
                        }
                        bool moreFiles = true;
                        while (moreFiles) {
                            string line = stream.ReadLine(Encoding.UTF8);
                            match = ContentDispositionFileRegex.Match(line);
                            if (!match.Success) {
                                return false;
                            }
                            string filename = match.Groups[1].Value;
                            if (!ParseMultipartFile(stream, form, fieldName, filename, fileBoundaryBytes)) {
                                return false;
                            }
                            line = stream.ReadLine(Encoding.UTF8);
                            if (line == "--") {
                                moreFiles = false;
                            }
                            else if (line != string.Empty) {
                                return false;
                            }
                        }
                        // NB: CrLf already ripped here
                        var boundaryNoCrLf = new byte[boundaryBytes.Length - 2];
                        Array.Copy(boundaryBytes, 2, boundaryNoCrLf, 0, boundaryBytes.Length - 2);
                        if (!stream.ReadTo(boundaryNoCrLf, out temp)) {
                            return false;
                        }
                        if (temp.Length != 0) {
                            return false;
                        }
                        return true;
                    }
                }
            }
            if (contentType == null) {
                contentType = "text/plain";
            }

            byte[] value;
            if (!stream.ReadTo(boundaryBytes, out value)) {
                return false;
            }
            // handle charset: content-type: text/plain;charset=windows-1250
            match = CharsetRegex.Match(contentType);
            Encoding encoding = match.Success ? Encoding.GetEncoding(match.Groups[2].Value) : Encoding.UTF8;
            form[fieldName] = encoding.GetString(value);

            return true;
        }

        private static bool ParseMultipartFile(Stream stream, FormData form, string fieldName, string fileName, byte[] boundaryBytes) {
            string contentType = null;
            string headerLine;
            while ((headerLine = stream.ReadLine(Encoding.UTF8)) != string.Empty) {
                // parse 'Content-" headers
                var match = ContentTypeFileRegex.Match(headerLine);
                if (match.Success) {
                    contentType = match.Groups[1].Value.Trim();
                }
            }
            if (contentType == null) {
                //todo: infer from file type (extension)
                contentType = "application/octet-stream";
            }

            byte[] data;
            if (!stream.ReadTo(boundaryBytes, out data)) {
                return false;
            }
            form.Files.Add(new PostedFile(fieldName, fileName, data, contentType));
            return true;
        }

        private class PostedFile : IPostedFile, IDisposable
        {
            private readonly int _contentLength;
            private readonly string _contentType;
            private readonly string _fieldName;
            private readonly string _fileName;
            private readonly Stream _stream;

            public PostedFile(string fieldName, string fileName, byte[] data, string contentType) {
                _fieldName = fieldName;
                _fileName = fileName;
                _stream = new MemoryStream(data, false);
                _contentLength = data.Length;
                _contentType = contentType;
            }

            public int ContentLength {
                get { return _contentLength; }
            }

            public string ContentType {
                get { return _contentType; }
            }

            public string FieldName {
                get { return _fieldName; }
            }

            public string FileName {
                get { return _fileName; }
            }

            public Stream InputStream {
                get { return _stream; }
            }

            public void Dispose() {
                _stream.Dispose();
            }
        }
    }
}