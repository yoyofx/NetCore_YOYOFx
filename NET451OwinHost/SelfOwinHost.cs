using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET451OwinHost
{
    public class SelfOwinHost
    {
        public static IDisposable Start(string uri)
        {
            return Microsoft.Owin.Hosting.WebApp.Start<Startup>(uri);
        }

    }
}
