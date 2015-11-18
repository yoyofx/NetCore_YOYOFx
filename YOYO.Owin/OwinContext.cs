using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YOYO.Owin.Helper;

namespace YOYO.Owin
{
    //public class OwinContext : IOwinContext, IDictionary<String, String>
    //{

    //    private readonly IDictionary<String, Object> _environment;
        
    //    public OwinContext(IDictionary<string,object> environment = null)
    //    {
    //        _environment = environment ?? new ConcurrentDictionary<string, object>(StringComparer.Ordinal);
    //        if (!_environment.ContainsKey( OwinConstants.Owin.CallCancelled ))
    //            _environment.Add(OwinConstants.Owin.CallCancelled, new CancellationToken());
    //    }


    //    public CancellationToken CancellationToken
    //    {
    //        get { return _environment.GetValue<CancellationToken>(OwinConstants.Owin.CallCancelled); }
    //    }


    //    public IDictionary<string, object> Environment
    //    {
    //        get
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }

    //    public string OwinVersion
    //    {
    //        get
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }
    //}
}
