using System.Collections.Generic;

namespace YOYO.Owin
{
    internal interface IHttpHeaders
    {
        IDictionary<string, string[]> Raw { get; }

        void Add(string key, string value);

        void Add(string key, IEnumerable<string> values);

        IEnumerable<string> Enumerate(string key);

        string GetValue(string key);
    }
}