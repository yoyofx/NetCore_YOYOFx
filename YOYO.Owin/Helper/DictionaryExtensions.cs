using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Owin.Helper
{
    internal static class DictionaryExtensions
    {
       public static Func<IDictionary<string, string[]>> createHeadersFunc =
                                    () => new ConcurrentDictionary<string, string[]>(StringComparer.OrdinalIgnoreCase);


        public static T GetNestedValueOrDefault<T>(this IDictionary<string, object> dictionary,
                                                   string key,
                                                   string subkey,
                                                   T defaultValue = default(T))
        {
            var subDictionary = dictionary.GetValueOrDefault<IDictionary<string, object>>(key);
            return subDictionary == null ? defaultValue : subDictionary.GetValueOrDefault(subkey, defaultValue);
        }

        public static T GetValue<T>(this IDictionary<string, object> dictionary, string key)
        {
            return (T)dictionary[key];
        }

        public static T GetValueOrCreate<T>(this IDictionary<string, object> dictionary, string key, Func<T> create)
        {
            object value;
            if (!dictionary.TryGetValue(key, out value))
            {
                value = create();
                if (value != null)
                {
                    // todo should we throw if null?
                    dictionary.Add(key, value);
                }
            }
            return (T)value;
        }

        public static T GetValueOrDefault<T>(this IDictionary<string, object> dictionary, string key, T defaultValue = default(T))
        {
            object value;
            if (dictionary.TryGetValue(key, out value))
            {
                return (T)value;
            }
            return defaultValue;
        }

        /// <summary>
        /// Sets the value if it is not null, with the specified key.
        /// 'null' values result in removing any item with the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetValue<T>(this IDictionary<string, object> dictionary, string key, T value)
        {
            if (value == null)
            {
                dictionary.Remove(key);
            }
            else
            {
                dictionary[key] = value;
            }
        }
    }
}
