using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Owin
{
    public class ResponseCookieCollection
    {
        /// <summary>
        /// Create a new wrapper
        /// </summary>
        /// <param name="headers"></param>
        public ResponseCookieCollection(IDictionary<string, string[]> headers)
        {
            if (headers == null)
            {
                throw new ArgumentNullException("headers");
            }

            Headers = headers;
        }

        private IDictionary<string, string[]> Headers { get; set; }

        /// <summary>
        /// Add a new cookie and value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Append(string key, string value)
        {
            AppendHeaderUnmodified(Headers,HttpHeaderKeys.SetCookie, Uri.EscapeDataString(key) + "=" + Uri.EscapeDataString(value) + "; path=/");
        }


        private void AppendHeaderUnmodified(IDictionary<string, string[]> headers, string key, params string[] values)
        {
            if (values == null || values.Length == 0)
            {
                return;
            }

            string[] existing = GetHeaderUnmodified(headers, key);
            if (existing == null)
            {
                SetHeaderUnmodified(headers, key, values);
            }
            else
            {
                SetHeaderUnmodified(headers, key, existing.Concat(values));
            }
        }
        private string[] GetHeaderUnmodified(IDictionary<string, string[]> headers, string key)
        {
            if (headers == null)
            {
                throw new ArgumentNullException("headers");
            }
            string[] values;
            return headers.TryGetValue(key, out values) ? values : null;
        }

        private void SetHeaderUnmodified(IDictionary<string, string[]> headers, string key, params string[] values)
        {
            if (headers == null)
            {
                throw new ArgumentNullException("headers");
            }
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException("key");
            }
            if (values == null || values.Length == 0)
            {
                headers.Remove(key);
            }
            else
            {
                headers[key] = values;
            }
        }
        private void SetHeaderUnmodified(IDictionary<string, string[]> headers, string key, IEnumerable<string> values)
        {
            if (headers == null)
            {
                throw new ArgumentNullException("headers");
            }
            headers[key] = values.ToArray();
        }

        /// <summary>
        /// Add a new cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public void Append(string key, string value, CookieOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            bool domainHasValue = !string.IsNullOrEmpty(options.Domain);
            bool pathHasValue = !string.IsNullOrEmpty(options.Path);
            bool expiresHasValue = options.Expires.HasValue;

            string setCookieValue = string.Concat(
                Uri.EscapeDataString(key),
                "=",
                Uri.EscapeDataString(value ?? string.Empty),
                !domainHasValue ? null : "; domain=",
                !domainHasValue ? null : options.Domain,
                !pathHasValue ? null : "; path=",
                !pathHasValue ? null : options.Path,
                !expiresHasValue ? null : "; expires=",
                !expiresHasValue ? null : options.Expires.Value.ToString("ddd, dd-MMM-yyyy HH:mm:ss ", CultureInfo.InvariantCulture) + "GMT",
                !options.Secure ? null : "; secure",
                !options.HttpOnly ? null : "; HttpOnly");


            AppendHeaderUnmodified(Headers, HttpHeaderKeys.SetCookie, setCookieValue);
        }

        /// <summary>
        /// Sets an expired cookie
        /// </summary>
        /// <param name="key"></param>
        public void Delete(string key)
        {
            Func<string, bool> predicate = value => value.StartsWith(key + "=", StringComparison.OrdinalIgnoreCase);

            var deleteCookies = new[] { Uri.EscapeDataString(key) + "=; expires=Thu, 01-Jan-1970 00:00:00 GMT" };

            IList<string> existingValues = Headers[HttpHeaderKeys.SetCookie];
            if (existingValues == null || existingValues.Count == 0)
            {
                SetHeaderUnmodified(Headers, HttpHeaderKeys.SetCookie, deleteCookies);
            }
            else
            {
                SetHeaderUnmodified(Headers, HttpHeaderKeys.SetCookie, existingValues.Where(value => !predicate(value)).Concat(deleteCookies).ToArray());
            }
        }

        /// <summary>
        /// Sets an expired cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="options"></param>
        public void Delete(string key, CookieOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            bool domainHasValue = !string.IsNullOrEmpty(options.Domain);
            bool pathHasValue = !string.IsNullOrEmpty(options.Path);

            Func<string, bool> rejectPredicate;
            if (domainHasValue)
            {
                rejectPredicate = value =>
                    value.StartsWith(key + "=", StringComparison.OrdinalIgnoreCase) &&
                        value.IndexOf("domain=" + options.Domain, StringComparison.OrdinalIgnoreCase) != -1;
            }
            else if (pathHasValue)
            {
                rejectPredicate = value =>
                    value.StartsWith(key + "=", StringComparison.OrdinalIgnoreCase) &&
                        value.IndexOf("path=" + options.Path, StringComparison.OrdinalIgnoreCase) != -1;
            }
            else
            {
                rejectPredicate = value => value.StartsWith(key + "=", StringComparison.OrdinalIgnoreCase);
            }


            
            IList<string> existingValues = GetHeaderUnmodified(Headers, HttpHeaderKeys.SetCookie);
            if (existingValues != null)
            {
                SetHeaderUnmodified(Headers, HttpHeaderKeys.SetCookie, existingValues.Where(value => !rejectPredicate(value)).ToArray());
            }

            Append(key, string.Empty, new CookieOptions
            {
                Path = options.Path,
                Domain = options.Domain,
                Expires = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            });
        }
    }
}
