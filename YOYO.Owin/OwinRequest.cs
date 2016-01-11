using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin.Helper;
using System.IO;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace YOYO.Owin
{
    internal class OwinRequest : IOwinRequest
    {
        private static readonly Regex MultipartRegex = new Regex(@"boundary=""?(?<token>[^\n\;\"" ]*)",
                                                                RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private readonly IDictionary<string, object> _environment;
        private readonly OwinRequestHeaders _headers;
        private QueryString _queryString;




        public OwinRequest(IDictionary<string, object> environment)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }
            RouteValues = new ConcurrentDictionary<string, string>();
            _environment = environment;
            var headers = _environment.GetValueOrCreate(OwinConstants.Request.Headers, DictionaryExtensions.createHeadersFunc);
            _headers = new OwinRequestHeaders(headers);
            this.ParseFormData();
        }

        private void ParseFormData()
        {
            var contentType = this.Headers.ContentType;
            if (String.IsNullOrEmpty(contentType))
                return;

            if (contentType == FormData.GetUrlEncodedContentType())
            {
                this.Form = FormData.ParseUrlEncoded(this.Body).Result;
            }
            else
            {
                var match = MultipartRegex.Match(contentType);
                if (match.Success)
                {
                    this.Form = FormData.ParseMultipart(this.Body, match.Groups["token"].Value)
                                                           .Result;
                }
            }

        }

        public void SetEnvironmentValue<T>(string key , T value)
        {
            _environment.SetValue<T>(key, value);
        }

        public T GetEnvironmentValue<T>(string key)
        {
            return _environment.GetValue<T>(key);
        }



        public Stream Body
        {
            get { return _environment.GetValue<Stream>(OwinConstants.Request.Body); }
            set { _environment.SetValue(OwinConstants.Request.Body, value); }
        }

        public IFormData Form
        {
            get { return _environment.GetValueOrDefault<IFormData>(OwinConstants.Simple.Form); }
            set { _environment.SetValue(OwinConstants.Simple.Form, value); }
        }

        public Uri FullUri
        {
            get { return _environment.GetValueOrCreate(OwinConstants.Simple.FullUri, MakeUri); }
            set
            {
                _environment.SetValue(OwinConstants.Simple.FullUri, value);
                //todo: should we automatically set all child parts if we know the PathBase?
                var pathBase = _environment.GetValueOrDefault<string>(OwinConstants.Request.PathBase);
                if (pathBase == null)
                {
                    return;
                }
                Scheme = value.Scheme;
                //todo: trim pathBase from path
                Path = value.AbsolutePath;
                QueryString = value.Query;
            }
        }

        public OwinRequestHeaders Headers
        {
            get { return _headers; }
        }

        public string Method
        {
            get { return _environment.GetValue<string>(OwinConstants.Request.Method); }
            set { _environment.SetValue(OwinConstants.Request.Method, value); }
        }

        public string Path
        {
            get { return _environment.GetValueOrDefault<string>(OwinConstants.Request.Path); }
            set { _environment.SetValue(OwinConstants.Request.Path, value); }
        }

        public string PathBase
        {
            get { return _environment.GetValueOrCreate(OwinConstants.Request.PathBase, () => string.Empty); }
            set { _environment.SetValue(OwinConstants.Request.PathBase, value); }
        }

        public string Protocol
        {
            get { return _environment.GetValueOrDefault<string>(OwinConstants.Request.Protocol); }
            set { _environment.SetValue(OwinConstants.Request.Protocol, value); }
        }

        public QueryString QueryString
        {
            get { return _queryString ?? (_queryString = _environment.GetValueOrDefault(OwinConstants.Request.QueryString, string.Empty)); }
            set
            {
                _queryString = value;
                _environment.SetValue(OwinConstants.Request.QueryString, value);
            }
        }

        public string Scheme
        {
            get { return _environment.GetValueOrDefault<string>(OwinConstants.Request.Scheme); }
            set { _environment.SetValue(OwinConstants.Request.Scheme, value); }
        }

        public IPrincipal User
        {
            get { return _environment.GetValueOrDefault<IPrincipal>(OwinConstants.Server.User); }
            set { _environment.SetValue(OwinConstants.Server.User, value); }
        }

        private Uri MakeUri()
        {
            var scheme = _environment.GetValueOrDefault(OwinConstants.Request.Scheme, "http");
            string host = Headers.Host ?? // should be here for http 1.1 requests
                          _environment.GetValueOrDefault<string>(OwinConstants.Server.LocalIpAddress) ?? // add port
                          "localhost"; // last resort
            int port = _environment.GetValueOrDefault(OwinConstants.Server.LocalPort, 80);
            var pathBase = _environment.GetValueOrDefault(OwinConstants.Request.PathBase, string.Empty);
            var path = _environment.GetValueOrDefault(OwinConstants.Request.Path, "/");
            var queryString = _environment.GetValueOrDefault(OwinConstants.Request.QueryString, string.Empty);
            var builder = new UriBuilder(scheme, host, port, pathBase + path, queryString);
            return builder.Uri;
        }

        IRequestHeaders IOwinRequest.Headers
        {
            get { return _headers; }
        }


        public IDictionary<string, string> RouteValues { set; get; }

        public string this[string key]
        {
            get
            {
                string reqValue = null;
                this.RouteValues.TryGetValue(key, out reqValue);
              
                if (string.IsNullOrEmpty(reqValue))
                    reqValue = this.QueryString[key];

                if (string.IsNullOrEmpty(reqValue) && this.Form !=null)
                    reqValue = this.Form["key"];

                return reqValue;
            }
        }

        public RequestCookieCollection Cookie
        {
            get
            {
                return new RequestCookieCollection(HeaderExtensions.GetCookies(this));
            }
        }

    }
}
