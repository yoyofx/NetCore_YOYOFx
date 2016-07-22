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
    public class HttpPostAttribute : HttpRouteAttribute
    {
        public HttpPostAttribute(string urlRole): base(urlRole){}


    }


}