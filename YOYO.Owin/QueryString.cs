using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using YOYO.Owin.Helper;

namespace YOYO.Owin
{
    public class QueryString
    {
        private readonly IDictionary<string, string> _parts;

        public QueryString(string value) {
            _parts = Parse(value);
        }

        public QueryString(IDictionary<string, string> parts) {
            _parts = parts;
        }

        public IDictionary<string, string> Parts {
            get { return _parts; }
        }

        public override string ToString() {
            var query = new StringBuilder();
            foreach (var part in Parts) 
                query.AppendFormat("{0}{1}{2}&", part.Key, part.Value == string.Empty ? string.Empty : "=", UrlHelper.Encode(part.Value));

            if (query.Length > 0) {
                query.Remove(query.Length - 1, 1);
            }
            return query.ToString();
        }

        private static IDictionary<string, string> Parse(string queryString) {
            if (queryString == string.Empty) {
                return new ConcurrentDictionary<string, string>();
            }
            var workingDictionary = new ConcurrentDictionary<string, string>();
            var chunks = queryString.Split('&');
            foreach (var chunk in chunks) {
                var parts = chunk.Split('=');
                if (!workingDictionary.ContainsKey(parts[0])) {
                    workingDictionary.TryAdd(parts[0], UrlHelper.Decode(parts[1]));
                }
            }
            return workingDictionary;
        }

        public static implicit operator QueryString(string raw) {
            return new QueryString(raw);
        }
    }
}