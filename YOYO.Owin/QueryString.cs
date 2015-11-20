using System.Collections.Generic;
using System.Linq;
using System.Text;
using YOYO.Owin.Helper;

namespace YOYO.Owin
{
    public class QueryString
    {
        private readonly IDictionary<string, string[]> _parts;

        public QueryString(string value) {
            _parts = Parse(value);
        }

        public QueryString(IDictionary<string, string[]> parts) {
            _parts = parts;
        }

        public IDictionary<string, string[]> Parts {
            get { return _parts; }
        }

        public override string ToString() {
            var query = new StringBuilder();
            foreach (var part in Parts) {
                foreach (var value in part.Value) {
                    query.AppendFormat("{0}{1}{2}&", part.Key, value == string.Empty ? string.Empty : "=", UrlHelper.Encode(value));
                }
            }
            if (query.Length > 0) {
                query.Remove(query.Length - 1, 1);
            }
            return query.ToString();
        }

        private static IDictionary<string, string[]> Parse(string queryString) {
            if (queryString == string.Empty) {
                return new Dictionary<string, string[]>();
            }
            var workingDictionary = new Dictionary<string, List<string>>();
            var chunks = queryString.Split('&');
            foreach (var chunk in chunks) {
                var parts = chunk.Split('=');
                if (!workingDictionary.ContainsKey(parts[0])) {
                    workingDictionary.Add(parts[0], new List<string>());
                }
                workingDictionary[parts[0]].Add(parts.Length == 2 ? UrlHelper.Decode(parts[1]) : string.Empty);
            }
            return workingDictionary.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToArray());
        }

        public static implicit operator QueryString(string raw) {
            return new QueryString(raw);
        }
    }
}