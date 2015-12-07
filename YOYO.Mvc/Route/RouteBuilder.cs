using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin;
using YOYO.Mvc.Extensions;

namespace YOYO.Mvc.Route
{
    public class RouteBuilder : IRouteBuilder
    {
        private static List<RouteRole> routeRoles = new List<RouteRole>();
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
            this.Map(new RouteRole(role));
            return this;
        }

		public IRouteBuilder Map(string role , string defaultControllerName = null, string defaultActionName = null )
		{
			this.Map(new RouteRole(role,defaultControllerName,defaultActionName));
			return this;
		}


        public  RouteResolveResult Resolve(IOwinRequest request)
        {
            RouteResolveResult result = null;
            var roles = routeRoles.Where(r => r.Method == HttpMethod.Both || r.Method.ToString().ToLower() == request.Method.ToLower());

            foreach(var role in roles)
            {

                var resolveResult = getRouteForUrl(request.Path, request.Method, role);
                if (resolveResult != null)
                {
                    result = resolveResult;
                    break;
                }

            }
            
            return result;

        }


        private RouteResolveResult getRouteForUrl(string path,string method, RouteRole role)
        {
			RouteResolveResult result = new RouteResolveResult() {  Url = path ,  ControllerName = role.DefaultController , 
																											ActionName = role.DefalutAction };
            List<RouteSegment> segments = role.Segments;
            var urlSegments = path.GetUrlSegments();

            for (int index = 0; index < urlSegments.Count; index++)
            {
                if (index < segments.Count)
                {

                    switch (segments[index].SegmentType)
                    {
                        case SegmentType.Directory:
                            if (segments[index].Segment != urlSegments[index] || segments[index].Index != index) result = null;
                            break;
						case SegmentType.Role:
							if (segments [index].Index == index) {
								var controllerOrAction = segments [index].GetSegmentValue (urlSegments [index]);
								if (segments [index].RouteNames [0] == "controller")
									result.ControllerName = controllerOrAction;
								else                                                       //"action"
	                                	result.ActionName = controllerOrAction;
							}
                            break;
                        case SegmentType.Parameter:
                            var segmentValue = urlSegments[index];
                            result.RouteValues.Add(segments[index].RouteNames[0], segmentValue);
                            break;

                    }
                }
                else
                {
                    int i = index - segments.Count;
                    result.RouteValues.Add("p" + i, urlSegments[index]);
                }

                if (result == null)
                    break;

            }

			if (result!=null && ( string.IsNullOrEmpty (result.ActionName) || string.IsNullOrEmpty (result.ControllerName) ) )
				return null;
			
            return result;
        }



    }
}
