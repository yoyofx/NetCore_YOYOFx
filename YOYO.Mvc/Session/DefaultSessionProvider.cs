using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin;

namespace YOYO.Mvc.Session
{
    internal class DefaultSessionProvider : ISessionProvider
    {
        private static DefaultSessionProvider _manager;

        private static object _lock = new object();

        private SessionsStore store = new SessionsStore();


        public static DefaultSessionProvider DefaultProvider
        {
            get
            {
                lock (_lock)
                {
                    if (null == _manager) _manager = new DefaultSessionProvider();
                    return _manager;
                }
            }
        }

        private static int _CheckSecond = 30;

        private static DateTime nextCheckTime = DateTime.Now.AddSeconds(_CheckSecond);

        private static Func<string, CookieSession, bool> _recoverFunc = (sid, s) =>
        {
            if (DateTime.Now > s.DeathTime) return true;
            return false;
        };

        private void OnSessionRequest()
        {
            if (DateTime.Now < nextCheckTime) return;
            store.RecoverSession(_recoverFunc);
            nextCheckTime = DateTime.Now.AddSeconds(_CheckSecond);
        }

        private void SetSession(string id, CookieSession session)
        {
            store.SetSession(id, session);
        }

        private CookieSession GetCurrentSession(IOwinContext context)
        {
            var sessionid = context.Request.Cookie["YOYOFx_SessionID"];
            if (string.IsNullOrEmpty(sessionid))
                return null;
            return store.GetSession(sessionid);
        }



        public ISession AccessSession(IOwinContext context)
        {
            OnSessionRequest();

            CookieSession session;
            session = GetCurrentSession(context);
            if(session==null)
            {
                string sessionid = Guid.NewGuid().ToString();
                session = new CookieSession() { ID = sessionid };
                store.SetSession(sessionid, session);
                context.Response.Cookies.Append("YOYOFx_SessionID", sessionid);

            }
            session.RefreshSessionAccessTime();
            store.SetSession(session.ID, session);

            return session;
        }


    }
}
