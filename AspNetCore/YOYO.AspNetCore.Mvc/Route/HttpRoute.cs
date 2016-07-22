using System;
using System.Threading;
using System.Threading.Tasks;
using YOYO.Owin;
using System.Reflection;
using YOYO.Mvc.ResponseProcessor;
using YOYO.Mvc.Session;
using YOYO.Extensions.DI;

namespace YOYO.Mvc.Route
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HttpRouteAttribute : System.Attribute
    {
        public HttpRouteAttribute(string urlRole)
        {
            this.UrlRole = urlRole;
        }

        public string UrlRole{ set; get; }
    }


}