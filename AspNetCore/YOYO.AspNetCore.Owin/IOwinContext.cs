using System.Collections.Generic;
using System.Threading;

namespace YOYO.AspNetCore.Owin
{
    public interface IOwinContext
    {
        CancellationToken CancellationToken { get; }

        IDictionary<string, object> Environment { get; }

        string OwinVersion { get; }

        IOwinRequest Request { get; }

        IOwinResponse Response { get; }

        IDictionary<string,object> Items { get; }
    }
}
