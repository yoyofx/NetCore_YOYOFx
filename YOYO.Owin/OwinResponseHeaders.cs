using System;
using System.Collections.Generic;
using System.Globalization;

namespace YOYO.Owin
{
    internal class OwinResponseHeaders : HttpHeaders, IResponseHeaders
    {
        public OwinResponseHeaders(IDictionary<string, string[]> raw)
            : base(raw) { }

        public string AcceptRanges {
            get { return GetValue(HttpHeaderKeys.AcceptRanges); }
            set { SetValue(HttpHeaderKeys.AcceptRanges, value); }
        }

        public string Age {
            get { return GetValue(HttpHeaderKeys.Age); }
            set { SetValue(HttpHeaderKeys.Age, value); }
        }

        public string CacheControl {
            get { return GetValue(HttpHeaderKeys.CacheControl); }
            set { SetValue(HttpHeaderKeys.CacheControl, value); }
        }

        public string Connection {
            get { return GetValue(HttpHeaderKeys.Connection); }
            set { SetValue(HttpHeaderKeys.Connection, value); }
        }

        public long ContentLength {
            get {
                string value = GetValue(HttpHeaderKeys.ContentLength);
                if (value == null) {
                    return -1;
                }
                return Convert.ToInt64(value);
            }
            set { SetValue(HttpHeaderKeys.ContentLength, value < 0 ? null : value.ToString(CultureInfo.InvariantCulture)); }
        }

        public string ContentType {
            get { return GetValue(HttpHeaderKeys.ContentType); }
            set { SetValue(HttpHeaderKeys.ContentType, value); }
        }

        public string ETag {
            get { return GetValue(HttpHeaderKeys.ETag); }
            set { SetValue(HttpHeaderKeys.ETag, value); }
        }

        public string Expires {
            get { return GetValue(HttpHeaderKeys.Expires); }
            set { SetValue(HttpHeaderKeys.Expires, value); }
        }

        public string LastModified {
            get { return GetValue(HttpHeaderKeys.LastModified); }
            set { SetValue(HttpHeaderKeys.LastModified, value); }
        }

        public string Location {
            get { return GetValue(HttpHeaderKeys.Location); }
            set { SetValue(HttpHeaderKeys.Location, value); }
        }

        public string Pragma {
            get { return GetValue(HttpHeaderKeys.Pragma); }
            set { SetValue(HttpHeaderKeys.Pragma, value); }
        }

        public string ProxyAuthenticate {
            get { return GetValue(HttpHeaderKeys.ProxyAuthenticate); }
            set { SetValue(HttpHeaderKeys.ProxyAuthenticate, value); }
        }

        public string RetryAfter {
            get { return GetValue(HttpHeaderKeys.RetryAfter); }
            set { SetValue(HttpHeaderKeys.RetryAfter, value); }
        }

        public string Server {
            get { return GetValue(HttpHeaderKeys.Server); }
            set { SetValue(HttpHeaderKeys.Server, value); }
        }

        public string Vary {
            get { return GetValue(HttpHeaderKeys.Vary); }
            set { SetValue(HttpHeaderKeys.Vary, value); }
        }

        public string WwwAuthenticate {
            get { return GetValue(HttpHeaderKeys.WwwAuthenticate); }
            set { SetValue(HttpHeaderKeys.WwwAuthenticate, value); }
        }
    }
}