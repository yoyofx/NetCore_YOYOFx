using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace YOYO.Mvc.Session
{
    internal class SessionsStore
    {
        private  IDictionary<string, Session> sessionStore = new ConcurrentDictionary<string,Session>();

        internal Session GetSession(string sessionid)
        {
            Session session = null;

            sessionStore.TryGetValue(sessionid,out session);

            return session;
        }  

        internal void SetSession(string id, Session session)
        {
            if (sessionStore.ContainsKey(id))
                sessionStore[id] = session;
            else
                sessionStore.Add(id, session);
        }

    }
}
