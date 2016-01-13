using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Mvc.Session
{
    internal class DefaultSessionManager : ISessionManager
    {
        private static DefaultSessionManager _manager;

        private static object _lock = new object();

        private SessionsStore store = new SessionsStore();


        public static DefaultSessionManager Manager
        {
            get
            {
                lock (_lock)
                {
                    if (null == _manager) _manager = new DefaultSessionManager();
                    return _manager;
                }
            }
        }

        public void OnRequest()
        {
            throw new NotImplementedException();
        }


        public void SetSession(string id,Session session)
        {
            store.SetSession(id, session);
        }

        public Session GetSession(string sessionid)
        {
            return store.GetSession(sessionid);
        }

    }
}
