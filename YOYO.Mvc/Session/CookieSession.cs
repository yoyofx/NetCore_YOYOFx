using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Mvc.Session
{
    public class CookieSession : ISession
    {
        public object this[string key]
        {
            get
            {
                object obj = null;
                this._userData.TryGetValue(key, out obj);
                return obj;
            }
            set
            {
                this._userData[key] = value;
            }
        }

        private IDictionary<string, object> _userData = new Dictionary<string, object>();

        internal DateTime DeathTime { get; set; }

        public string ID { set; get; }

        public void RefreshSessionAccessTime()
        {
            DeathTime = DateTime.Now.AddMinutes(30);
        }

    }
}
