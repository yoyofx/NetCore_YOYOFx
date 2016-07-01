using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.IO;
using YOYO.Owin.Helper;
using System.Threading.Tasks;

namespace YOYO.Owin
{
    internal class OwinResponse : IOwinResponse
    {
        private readonly IDictionary<string, object> _environment;
        private readonly OwinResponseHeaders _headers;


        public OwinResponse(IDictionary<string, object> environment) {
            if (environment == null) {
                throw new ArgumentNullException("environment");
            }
            _environment = environment;
            var headers = _environment.GetValueOrCreate(OwinConstants.Response.Headers, DictionaryExtensions.createHeadersFunc );
            _headers = new OwinResponseHeaders(headers);
        }

        public ResponseCookieCollection Cookies
        {
            get { return new ResponseCookieCollection(this.Headers.ToDictionary()); }
        }

        public void Write(byte[] bytes)
        {
            this.Headers.ContentLength = bytes.Length;
            this.Body.Write(bytes, 0, bytes.Length);
        }

        public void Write(string text)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);
            this.Write(bytes);
        }

        public Task WriteAsync(byte[] bytes)
        {
            this.Headers.ContentLength = bytes.Length;
            return this.Body.WriteAsync(bytes, 0, bytes.Length);
        }

        public Task WriteAsync(byte[] bytes,int length)
        {
            return this.Body.WriteAsync(bytes, 0, length);
        }


        public Task WriteAsync(string text)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);
            return this.WriteAsync(bytes);
        }


        public Stream Body {
            get { return _environment.GetValue<Stream>(OwinConstants.Response.Body); }
            set { _environment.SetValue(OwinConstants.Response.Body, value); }
        }

        public OwinResponseHeaders Headers {
            get { return _headers; }
        }

        public string Protocol {
            get { return _environment.GetValueOrDefault<string>(OwinConstants.Response.Protocol); }
            set { _environment.SetValue(OwinConstants.Response.Protocol, value); }
        }

        public Status Status {
            get {
                //pull
                var status = _environment.GetValueOrDefault<Status>(OwinConstants.Simple.Status);
                if (status != null) {
                    return status;
                }
                //build
                var code = _environment.GetValueOrDefault(OwinConstants.Response.StatusCode, 0);
                if (code != 0) {
                    return new Status(code, _environment.GetValueOrDefault(OwinConstants.Response.ReasonPhrase, string.Empty));
                }
                //default
                return Status.Is.OK;
            }
            set {
                if (value == null) {
                    _environment.Remove(OwinConstants.Response.StatusCode);
                    _environment.Remove(OwinConstants.Response.ReasonPhrase);
                }
                else {
                    _environment.SetValue(OwinConstants.Response.StatusCode, value.Code);
                    _environment.SetValue(OwinConstants.Response.ReasonPhrase, value.Description);
                    if (value.LocationHeader != null) {
                        _headers.Location = value.LocationHeader;
                    }
                }
            }
        }

        public void OnSendingHeaders(Action<object> callback, object state) {
            var serverOnSendingHeaders = _environment.GetValueOrDefault<Action<Action<object>, object>>(OwinConstants.Server.OnSendingHeaders);
            if (serverOnSendingHeaders == null) {
                throw new NotSupportedException("The server does not support 'OnSendingHeaders'");
            }
            serverOnSendingHeaders(callback, state);
        }

        public void RemoveCookie(string cookieName) {
            _headers.Add(HttpHeaderKeys.SetCookie, string.Format("{0}=; Expires=Thu, 01 Jan 1970 00:00:00 GMT", cookieName));
        }

        public void SetLastModified(DateTime when) {
            _headers.LastModified = when.ToUniversalTime()
                                        .ToString("R");
        }

        public void SetLastModified(DateTimeOffset when) {
            _headers.LastModified = when.ToString("r");
        }


        IResponseHeaders IOwinResponse.Headers {
            get { return _headers; }
        }


        public virtual void Redirect(string location)
        {
            this.Status = Status.Is.Found(location);
            this.Headers.SetValue(HttpHeaderKeys.Location,location);
        }


    }
}