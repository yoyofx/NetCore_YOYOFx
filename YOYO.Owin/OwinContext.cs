using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YOYO.Owin.Helper;

namespace YOYO.Owin
{
    public class OwinContext : IOwinContext, IDictionary<String, object>
    {

        private readonly IDictionary<String, Object> _environment;

        public OwinContext(IDictionary<string, object> environment = null)
        {
            _environment = environment ?? new ConcurrentDictionary<string, object>(StringComparer.Ordinal);
            if (!_environment.ContainsKey(OwinConstants.Owin.CallCancelled))
                _environment.Add(OwinConstants.Owin.CallCancelled, new CancellationToken());
        }

        #region IOwinContext Members   


        public IDictionary<string, object> Environment
        {
            get { return _environment; }
        }

        public CancellationToken CancellationToken
        {
            get { return _environment.GetValue<CancellationToken>(OwinConstants.Owin.CallCancelled); }
        }



        public string OwinVersion
        {
            get { return _environment.GetValue<string>(OwinConstants.Owin.Version); }
            set { _environment.SetValue(OwinConstants.Owin.Version, value); }
        }


        public TextWriter TraceOutput
        {
            get { return _environment.GetValueOrDefault<TextWriter>(OwinConstants.Host.TraceOutput); }
            set { _environment.SetValue(OwinConstants.Host.TraceOutput, value); }
        }

        #endregion

        #region IDictionary Members
        object IDictionary<string, object>.this[string key]
        {
            get { return _environment[key]; }
            set { _environment[key] = value; }
        }

        ICollection<string> IDictionary<string, object>.Keys
        {
            get { return _environment.Keys; }
        }

        ICollection<object> IDictionary<string, object>.Values
        {
            get { return _environment.Values; }
        }

        void IDictionary<string, object>.Add(string key, object value)
        {
            _environment.Add(key, value);
        }

        bool IDictionary<string, object>.ContainsKey(string key)
        {
            return _environment.ContainsKey(key);
        }

        bool IDictionary<string, object>.Remove(string key)
        {
            return _environment.Remove(key);
        }

        bool IDictionary<string, object>.TryGetValue(string key, out object value)
        {
            return _environment.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _environment.GetEnumerator();
        }

        IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
        {
            return _environment.GetEnumerator();
        }


        int ICollection<KeyValuePair<string, object>>.Count
        {
            get { return _environment.Count; }
        }

        bool ICollection<KeyValuePair<string, object>>.IsReadOnly
        {
            get { return _environment.IsReadOnly; }
        }

        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
        {
            _environment.Add(item);
        }

        void ICollection<KeyValuePair<string, object>>.Clear()
        {
            _environment.Clear();
        }

        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
        {
            return _environment.Contains(item);
        }

        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            _environment.CopyTo(array, arrayIndex);
        }

        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
        {
            return _environment.Remove(item);
        }


        #endregion



    }
}
