using System.Collections.Generic;

namespace YOYO.Owin
{
    internal class OwinRequestHeaders : HttpHeaders, IRequestHeaders
    {
        public OwinRequestHeaders(IDictionary<string, string[]> raw)
            : base(raw) { }

        public string Accept {
            get { return GetValue(HttpHeaderKeys.Accept) ?? "*/*"; }
            set { SetValue(HttpHeaderKeys.Accept, value); }
        }

        public string AcceptCharset {
            get { return GetValue(HttpHeaderKeys.AcceptCharset); }
            set { SetValue(HttpHeaderKeys.AcceptCharset, value); }
        }

        public string AcceptEncoding {
            get { return GetValue(HttpHeaderKeys.AcceptEncoding); }
            set { SetValue(HttpHeaderKeys.AcceptEncoding, value); }
        }

        public string AcceptLanguage {
            get { return GetValue(HttpHeaderKeys.AcceptLanguage); }
            set { SetValue(HttpHeaderKeys.AcceptLanguage, value); }
        }

        public string Authorization {
            get { return GetValue(HttpHeaderKeys.Authorization); }
            set { SetValue(HttpHeaderKeys.Authorization, value); }
        }

        public string ContentType {
            get { return GetValue(HttpHeaderKeys.ContentType); }
            set { SetValue(HttpHeaderKeys.ContentType, value); }
        }

        public string Expect {
            get { return GetValue(HttpHeaderKeys.Expect); }
            set { SetValue(HttpHeaderKeys.Expect, value); }
        }

        public string From {
            get { return GetValue(HttpHeaderKeys.From); }
            set { SetValue(HttpHeaderKeys.From, value); }
        }

        public string Host {
            get { return GetValue(HttpHeaderKeys.Host); }
            set { SetValue(HttpHeaderKeys.Host, value); }
        }

        public string IfMatch {
            get { return GetValue(HttpHeaderKeys.IfMatch); }
            set { SetValue(HttpHeaderKeys.IfMatch, value); }
        }

        public string IfModifiedSince {
            get { return GetValue(HttpHeaderKeys.IfModifiedSince); }
            set { SetValue(HttpHeaderKeys.IfModifiedSince, value); }
        }

        public string IfNoneMatch {
            get { return GetValue(HttpHeaderKeys.IfNoneMatch); }
            set { SetValue(HttpHeaderKeys.IfNoneMatch, value); }
        }

        public string IfRange {
            get { return GetValue(HttpHeaderKeys.IfRange); }
            set { SetValue(HttpHeaderKeys.IfRange, value); }
        }

        public string IfUnmodifiedSince {
            get { return GetValue(HttpHeaderKeys.IfUnmodifiedSince); }
            set { SetValue(HttpHeaderKeys.IfUnmodifiedSince, value); }
        }

        public string MaxForwards {
            get { return GetValue(HttpHeaderKeys.MaxForwards); }
            set { SetValue(HttpHeaderKeys.MaxForwards, value); }
        }

        public string ProxyAuthorization {
            get { return GetValue(HttpHeaderKeys.ProxyAuthorization); }
            set { SetValue(HttpHeaderKeys.ProxyAuthorization, value); }
        }

        public string Range {
            get { return GetValue(HttpHeaderKeys.Range); }
            set { SetValue(HttpHeaderKeys.Range, value); }
        }

        public string Referer {
            get { return GetValue(HttpHeaderKeys.Referer); }
            set { SetValue(HttpHeaderKeys.Referer, value); }
        }

        public string TE {
            get { return GetValue(HttpHeaderKeys.TE); }
            set { SetValue(HttpHeaderKeys.TE, value); }
        }

        public string UserAgent {
            get { return GetValue(HttpHeaderKeys.UserAgent); }
            set { SetValue(HttpHeaderKeys.UserAgent, value); }
        }
    }
}