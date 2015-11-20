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
    }
}