namespace YOYO.Owin
{
    public interface IRequestHeaders : IHttpHeaders
    {
        string Accept { get; set; }

        string AcceptCharset { get; set; }

        string AcceptEncoding { get; set; }

        string AcceptLanguage { get; set; }

        string Authorization { get; set; }

        string ContentType { get; set; }

        string Expect { get; set; }

        string From { get; set; }

        string Host { get; set; }

        string IfMatch { get; set; }

        string IfModifiedSince { get; set; }

        string IfNoneMatch { get; set; }

        string IfRange { get; set; }

        string IfUnmodifiedSince { get; set; }

        string MaxForwards { get; set; }

        string ProxyAuthorization { get; set; }

        string Range { get; set; }

        string Referer { get; set; }

        string TE { get; set; }

        string UserAgent { get; set; }
    }
}