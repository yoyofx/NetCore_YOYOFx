using System;
using System.Collections.Generic;
using System.Linq;

namespace YOYO.Owin.Helper
{
    internal static class HeaderExtensions
    {
        public static void AddValue(this IDictionary<string, string[]> dictionary, string key, string value) {
            string[] items;
            if (dictionary.TryGetValue(key, out items)) {
                Array.Resize(ref items, items.Length + 1);
            }
            else {
                items = new string[1];
            }
            items[items.Length - 1] = value;
            dictionary[key] = items;
        }

        public static void AddValues(this IDictionary<string, string[]> dictionary, string key, IEnumerable<string> values) {
            string[] items;
            List<string> list = values.ToList();
            if (dictionary.TryGetValue(key, out items)) {
                Array.Resize(ref items, items.Length + list.Count);
            }
            else {
                items = new string[list.Count];
            }
            list.CopyTo(items, items.Length);
            dictionary[key] = items;
        }


        internal static IDictionary<string, string> GetCookies(IOwinRequest request)
        {

            var cookies = request.GetEnvironmentValue<IDictionary<string, string>>("Microsoft.Owin.Cookies#dictionary");
            if (cookies == null)
            {
                cookies = new Dictionary<string, string>(StringComparer.Ordinal);
                request.SetEnvironmentValue("Microsoft.Owin.Cookies#dictionary", cookies);
            }

            string text = request.Headers.GetValue("Cookie");


            ;
            if (request.GetEnvironmentValue<string>("Microsoft.Owin.Cookies#text") != text)
            {
                cookies.Clear();
                ParseDelimited(text, SemicolonAndComma, AddCookieCallback, cookies);
                request.SetEnvironmentValue("Microsoft.Owin.Cookies#text",text);
            }
            return cookies;
        }
        private static readonly Action<string, string, object> AddCookieCallback = (name, value, state) =>
        {
            var dictionary = (IDictionary<string, string>)state;
            if (!dictionary.ContainsKey(name))
            {
                dictionary.Add(name, value);
            }
        };

        private static readonly char[] SemicolonAndComma = new[] { ';', ',' };

        internal static void ParseDelimited(string text, char[] delimiters, Action<string, string, object> callback, object state)
        {
            int textLength = text.Length;
            int equalIndex = text.IndexOf('=');
            if (equalIndex == -1)
            {
                equalIndex = textLength;
            }
            int scanIndex = 0;
            while (scanIndex < textLength)
            {
                int delimiterIndex = text.IndexOfAny(delimiters, scanIndex);
                if (delimiterIndex == -1)
                {
                    delimiterIndex = textLength;
                }
                if (equalIndex < delimiterIndex)
                {
                    while (scanIndex != equalIndex && char.IsWhiteSpace(text[scanIndex]))
                    {
                        ++scanIndex;
                    }
                    string name = text.Substring(scanIndex, equalIndex - scanIndex);
                    string value = text.Substring(equalIndex + 1, delimiterIndex - equalIndex - 1);
                    callback(
                        Uri.UnescapeDataString(name.Replace('+', ' ')),
                        Uri.UnescapeDataString(value.Replace('+', ' ')),
                        state);
                    equalIndex = text.IndexOf('=', delimiterIndex);
                    if (equalIndex == -1)
                    {
                        equalIndex = textLength;
                    }
                }
                scanIndex = delimiterIndex + 1;
            }
        }
    

}
}