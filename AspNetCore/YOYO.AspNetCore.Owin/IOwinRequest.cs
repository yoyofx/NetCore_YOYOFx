using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.AspNetCore.Owin
{
    public interface IOwinRequest
    {
       
        /// <summary>
        /// Gets the input body stream.
        /// </summary>
        Stream Body { get; }

        IFormData Form{ get; set; }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        Uri FullUri { get; }

        /// <summary>
        /// Gets the request headers.
        /// </summary>
        IRequestHeaders Headers { get; }

        /// <summary>
        /// Gets the HTTP method.
        /// </summary>
        string Method { get; }

        string Path { get; }

        string PathBase { get; }

        string Protocol { get; }

        /// <summary>
        /// Gets the query string.
        /// </summary>
        QueryString QueryString { get; }

        string Scheme { get; }

        IPrincipal User { get; set; }

        string this[string key] { get; }
        IDictionary<string, string> RouteValues{set; get; }

        void SetEnvironmentValue<T>(string key, T value);
        T GetEnvironmentValue<T>(string key);

        RequestCookieCollection Cookie { get; }
    }
}
