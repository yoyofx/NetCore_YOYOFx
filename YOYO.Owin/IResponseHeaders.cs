namespace YOYO.Owin
{
    public interface IResponseHeaders : IHttpHeaders
    {
        string AcceptRanges { get; set; }

        string Age { get; set; }

        string CacheControl { get; set; }

        string Connection { get; set; }

        long ContentLength { get; set; }

        string ContentType { get; set; }

        string ETag { get; set; }

        string Expires { get; set; }

        string LastModified { get; set; }

        string Location { get; set; }

        string Pragma { get; set; }

        string ProxyAuthenticate { get; set; }

        string RetryAfter { get; set; }

        string Server { get; set; }

        string Vary { get; set; }

        string WwwAuthenticate { get; set; }
    }
}