using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YOYO.Owin.Helper
{
    internal static partial class StreamExtensions
    {
        private const int CR = '\r';
        private const int LF = '\n';

        //public static Task CopyToAsync(this Stream source,
        //                               Stream destination,
        //                               long? lengthToCopy = null,
        //                               CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    if (source == null)
        //    {
        //        throw new ArgumentNullException("source");
        //    }
        //    if (destination == null)
        //    {
        //        throw new ArgumentNullException("destination");
        //    }
        //    long bufferSize = 4096;
        //    if (lengthToCopy.HasValue)
        //    {
        //        bufferSize = Math.Min(bufferSize, lengthToCopy.Value);
        //    }

        //    var copyExecutor = new AsyncCopyExecutor(source, destination, (int)bufferSize, lengthToCopy, cancellationToken);
        //    return copyExecutor.Start();
        //}

        /// <summary>
        ///     Reads a complete stream
        /// </summary>
        /// <returns>The contents of the stream</returns>
        public static string ReadAll(this Stream stream, Encoding encoding = null)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            using (var sr = new StreamReader(stream, encoding))
            {
                return sr.ReadToEnd();
            }
        }

        //public static Task<string> ReadAllAsync(this Stream stream,
        //                                        Encoding encoding = null,
        //                                        CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    if (stream == null)
        //    {
        //        throw new ArgumentNullException("stream");
        //    }
        //    if (encoding == null)
        //    {
        //        encoding = Encoding.UTF8;
        //    }
        //    return stream.ReadAllBytesAsync(cancellationToken)
        //                 .Then(bytes => encoding.GetString(bytes));
        //}

        /// <summary>
        ///     Reads all bytes from a stream and returns a byte array
        /// </summary>
        /// <param name="stream">The stream to read data from</param>
        public static byte[] ReadAllBytes(this Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            var temp = new MemoryStream(stream.CanSeek ? (int)stream.Length : 0);
            stream.CopyTo(temp);
            return temp.ToArray();
        }

        //public static Task<byte[]> ReadAllBytesAsync(this Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    if (stream == null)
        //    {
        //        throw new ArgumentNullException("stream");
        //    }
        //    var temp = new MemoryStream(stream.CanSeek ? (int)stream.Length : 0);
        //    return stream.CopyToAsync(temp, null, cancellationToken)
        //                 .Then(() => temp.ToArray());
        //}

        public static string ReadLine(this Stream stream, Encoding encoding = null)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            var buffer = new List<byte>();
            int current = 0;
            while (true)
            {
                int previous = current;
                current = stream.ReadByte();
                if (current == -1)
                {
                    if (buffer.Count == 0)
                    {
                        return null;
                    }
                    break;
                }
                if (current == LF)
                {
                    if (previous == CR)
                    {
                        buffer.RemoveAt(buffer.Count - 1);
                    }
                    break;
                }
                buffer.Add((byte)current);
            }
            return encoding.GetString(buffer.ToArray());
        }

        /// <summary>
        ///     Reads a stream line by line
        /// </summary>
        /// <returns>The read lines</returns>
        public static List<string> ReadLines(this Stream stream, Encoding encoding = null)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            var lines = new List<string>();
            using (var sr = new StreamReader(stream, encoding))
            {
                while (sr.Peek() >= 0)
                {
                    lines.Add(sr.ReadLine());
                }
            }
            return lines;
        }

        public static bool ReadTo(this Stream stream, byte[] lookFor, out byte[] buffer, bool includeLookFor = false)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            if (lookFor == null)
            {
                throw new ArgumentNullException("lookFor");
            }
            var temp = new MemoryStream();
            var matched = new byte[lookFor.Length];
            int matchedLength = 0;
            while (true)
            {
                int value = stream.ReadByte();
                if (value == -1)
                {
                    if (matchedLength > 0)
                    {
                        temp.Write(matched, 0, matchedLength);
                    }
                    buffer = temp.ToArray();
                    return false;
                }
                if (value == lookFor[matchedLength])
                {
                    matched[matchedLength] = (byte)value;
                    matchedLength++;
                    if (matchedLength == lookFor.Length)
                    {
                        if (includeLookFor)
                        {
                            temp.Write(lookFor);
                        }
                        buffer = temp.ToArray();
                        return true;
                    }
                    continue;
                }
                if (matchedLength > 0)
                {
                    //rescan match buffer before reading more
                    int start = 1;
                    for (; start < matchedLength; start++)
                    {
                        for (int i = 0; i < matchedLength; i++)
                        {
                            if (lookFor[i] != matched[start + i])
                            {
                                break;
                            }
                        }
                    }
                    //write unmatched
                    temp.Write(matched, 0, start);
                    //shift matched
                    matchedLength -= start;
                    for (int i = 0; i < matchedLength; i++)
                    {
                        matched[i] = matched[start];
                    }
                }
                temp.WriteByte((byte)value);
            }
        }

        /// <summary>
        ///     Sets the stream cursor to the beginning of the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>The stream</returns>
        public static Stream SeekToBegin(this Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            if (stream.CanSeek == false)
            {
                throw new InvalidOperationException("Stream does not support seeking.");
            }
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        /// <summary>
        ///     Sets the stream cursor to the end of the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>The stream</returns>
        public static Stream SeekToEnd(this Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            if (stream.CanSeek == false)
            {
                throw new InvalidOperationException("Stream does not support seeking.");
            }
            stream.Seek(0, SeekOrigin.End);
            return stream;
        }

        public static void Write(this Stream stream, string data, Encoding encoding = null)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            byte[] buffer = encoding.GetBytes(data);
            stream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        ///     Writes all passed bytes to the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="data">The byte array / buffer.</param>
        public static void Write(this Stream stream, byte[] data)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            stream.Write(data, 0, data.Length);
        }

        public static Task WriteAsync(this Stream stream,
                                      string data,
                                      Encoding encoding = null,
                                      CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (cancellationToken.IsCancellationRequested)
            {
                return OwinConstants.TaskHelper.Canceled();
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            byte[] buffer = encoding.GetBytes(data);
            return stream.WriteAsync(buffer, 0, buffer.Length, cancellationToken);
        }

        public static Task WriteAsync(this Stream stream, byte[] data, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (cancellationToken.IsCancellationRequested)
            {
                return OwinConstants.TaskHelper.Canceled();
            }
            return stream.WriteAsync(data, 0, data.Length, cancellationToken);
        }

        //private class AsyncCopyExecutor
        //{
        //    private readonly byte[] _buffer;
        //    private readonly TaskCompletionSource<int> _completion;
        //    private readonly Stream _destination;
        //    private readonly Stream _source;
        //    private CancellationToken _cancellationToken;
        //    private long? _lengthToCopy;

        //    internal AsyncCopyExecutor(Stream source,
        //                               Stream destination,
        //                               int bufferSize,
        //                               long? lengthToCopy,
        //                               CancellationToken cancellationToken)
        //    {
        //        _source = source;
        //        _destination = destination;
        //        _buffer = new byte[bufferSize];
        //        _lengthToCopy = lengthToCopy;
        //        _cancellationToken = cancellationToken;
        //        _completion = new TaskCompletionSource<int>();
        //    }

        //    internal Task Start()
        //    {
        //        Read();
        //        return _completion.Task;
        //    }

        //    private void Cancel()
        //    {
        //        _completion.TrySetCanceled();
        //    }

        //    private void Complete()
        //    {
        //        _completion.TrySetResult(0);
        //    }

        //    private void Fail(Exception exception)
        //    {
        //        _completion.TrySetException(exception);
        //    }

        //    private void Read()
        //    {
        //        if (_lengthToCopy.HasValue && _lengthToCopy.Value <= 0)
        //        {
        //            Complete();
        //            return;
        //        }
        //        if (_cancellationToken.IsCancellationRequested)
        //        {
        //            Cancel();
        //            return;
        //        }
        //        try
        //        {
        //            long readLength = _buffer.Length;
        //            if (_lengthToCopy.HasValue)
        //            {
        //                readLength = Math.Min(_lengthToCopy.Value, readLength);
        //            }
        //            IAsyncResult async = _source.BeginRead(_buffer, 0, (int)readLength, ar => ReadFinalizer(ar, true), null);
        //            ReadFinalizer(async, false);
        //        }
        //        catch (Exception ex)
        //        {
        //            Fail(ex);
        //        }
        //    }

        //    private void ReadFinalizer(IAsyncResult async, bool isAsync)
        //    {
        //        if (async.CompletedSynchronously == isAsync)
        //        {
        //            return;
        //        }
        //        try
        //        {
        //            int length = _source.EndRead(async);
        //            if (_cancellationToken.IsCancellationRequested)
        //            {
        //                Cancel();
        //                return;
        //            }
        //            Write(length);
        //        }
        //        catch (Exception ex)
        //        {
        //            Fail(ex);
        //        }
        //    }

        //    private void Write(int length)
        //    {
        //        if (length == 0)
        //        {
        //            Complete();
        //            return;
        //        }
        //        if (_cancellationToken.IsCancellationRequested)
        //        {
        //            Cancel();
        //            return;
        //        }
        //        try
        //        {
        //            if (_lengthToCopy.HasValue)
        //            {
        //                _lengthToCopy -= length;
        //            }
        //            IAsyncResult async = _destination.BeginWrite(_buffer, 0, length, ar => WriteFinalizer(ar, true), null);
        //            WriteFinalizer(async, false);
        //        }
        //        catch (Exception ex)
        //        {
        //            Fail(ex);
        //        }
        //    }

        //    private void WriteFinalizer(IAsyncResult async, bool isAsync)
        //    {
        //        if (async.CompletedSynchronously == isAsync)
        //        {
        //            return;
        //        }
        //        try
        //        {
        //            _destination.EndWrite(async);
        //            if (_cancellationToken.IsCancellationRequested)
        //            {
        //                Cancel();
        //                return;
        //            }
        //            Read();
        //        }
        //        catch (Exception ex)
        //        {
        //            Fail(ex);
        //        }
        //    }
        //}
    }
}