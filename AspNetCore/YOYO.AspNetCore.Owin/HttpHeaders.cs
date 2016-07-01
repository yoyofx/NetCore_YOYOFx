using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Concurrent;
using YOYO.Owin.Helper;

namespace YOYO.Owin
{
    internal class HttpHeaders
    {
        private readonly IDictionary<string, string[]> _raw;

        public HttpHeaders(IDictionary<string, string[]> raw = null) {
            _raw = raw ?? new ConcurrentDictionary<string, string[]>();
        }

        public IDictionary<string, string[]> Raw {
            get { return _raw; }
        }

        public void Add(string key, string value) {
            _raw.AddValue(key, value);
        }

        public void Add(string key, IEnumerable<string> values) {
            _raw.AddValues(key, values);
        }

        public void AddRaw(string keyAndValue) {
            string[] split = keyAndValue.Split(':');
            if (split.Length > 2) {
                throw new Exception("invalid header format.");
            }
            _raw.AddValue(split[0], split.Length == 1 ? string.Empty : split[1].Trim());
        }

        /// <summary>
        /// Parses and adds headers, includes multiline support
        /// </summary>
        /// <param name="rawheaders"></param>
        public void AddRaw(IList<string> rawheaders) {
            for (int i = 0; i < rawheaders.Count; i++) {
                string headerLine = rawheaders[i];
                int colon = headerLine.IndexOf(':');
                string headerName = headerLine.Substring(0, colon);
                headerLine = headerLine.Substring(colon + 1)
                                       .Trim();
                while (i < rawheaders.Count - 1 && char.IsWhiteSpace(rawheaders[i + 1][0])) {
                    headerLine = string.Format("{0} {1}", headerLine, rawheaders[i + 1].Trim());
                    i++;
                }
                _raw.AddValue(headerName, headerLine);
            }
        }

        public IEnumerable<string> Enumerate(string key) {
            string[] items;
            return !_raw.TryGetValue(key, out items)
                       ? Enumerable.Empty<string>()
                       : items.Select(item => item.Split(','))
                              .SelectMany(parts => parts);
        }

        public string GetValue(string key) {
            string[] values;
            if (!_raw.TryGetValue(key, out values)) {
                return null;
            }

            switch (values.Length) {
                case 0:
                    return string.Empty;
                case 1:
                    return values[0];
                default:
                    return string.Join(",", values);
            }
        }

        public bool Has(string key) {
            return _raw.ContainsKey(key);
        }

        public void MergeIn(HttpHeaders other) {
            foreach (var pair in other.Raw) {
                foreach (var value in pair.Value) {
                    _raw.AddValue(pair.Key, value);
                }
            }
        }

        public void SetValue(string key, string value) {
            if (value == null) {
                _raw.Remove(key);
            }
            else {
                _raw[key] = new[] { value };
            }
        }

        public bool ValueIs(string key, string expected, bool caseSensitive) {
            string actual = GetValue(key);
            if (actual == null && expected == null) {
                return true;
            }
            if (actual == null || expected == null) {
                return false;
            }
            return actual.Equals(expected, caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
        }
    }
}