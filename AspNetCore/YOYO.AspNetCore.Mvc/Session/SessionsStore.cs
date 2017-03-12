using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace YOYO.AspNetCore.Mvc.Session
{
    internal class SessionsStore
    {
        private  IDictionary<string, CookieSession> sessionStore = new ConcurrentDictionary<string, CookieSession>();

        internal CookieSession GetSession(string sessionid)
        {
            CookieSession session = null;

            sessionStore.TryGetValue(sessionid,out session);

            return session;
        }  

        internal void SetSession(string id, CookieSession session)
        {
            if (sessionStore.ContainsKey(id))
                sessionStore[id] = session;
            else
                sessionStore.Add(id, session);
        }

        internal void RecoverSession(Func<string, CookieSession, bool> recoverFunc)
        {
            var sessionIds = sessionStore.Keys.ToArray();
           
            foreach(var sessionid in sessionIds)
            {
                if(recoverFunc(sessionid, GetSession(sessionid) ))
                {
                    sessionStore.Remove(sessionid);
                }
            }
        }


    }
}
