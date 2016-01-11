using System.IO;
using System.Threading.Tasks;

namespace YOYO.Owin
{
    /// <summary>
    /// Abstraction for an HTTP response, to be implemented by hosting.
    /// </summary>
    public interface IOwinResponse
    {
        Stream Body { get; }

        /// <summary>
        /// The response headers.
        /// </summary>
        IResponseHeaders Headers { get; }

        ResponseCookieCollection Cookies { get;  }

        /// <summary>
        /// Gets or sets the status code and description.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        Status Status { get; set; }


        void Write(byte[] bytes);

        void Write(string text);

        Task WriteAsync(byte[] bytes);

        Task WriteAsync(string text);

    }
}