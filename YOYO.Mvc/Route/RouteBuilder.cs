using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin;

namespace YOYO.Mvc.Route
{
    public class RouteBuilder : IRouteBuilder
    {
        private List<RouteRole> routeRoles = new List<RouteRole>();
        private static readonly object lockObject = new object();
        private static IRouteBuilder _builder;


        public static IRouteBuilder Builder
        {
            get
            {
                lock (lockObject)
                {
                    if (_builder == null)
                    {
                        _builder = new RouteBuilder();
                    }

                    return _builder;

                }
            }
        }


        public IRouteBuilder Map(RouteRole role)
        {
            routeRoles.Add(role);
            return this;
        }

        public IRouteBuilder Map(string role)
        {
            this.Map(role);
            return this;
        }




        public RouteResolveResult Resolve(IOwinRequest request)
        {
            


            foreach(var role in  routeRoles)
            {
               
            }
            
            return null;

        }
    }
}
