namespace YOYO.Mvc.Route
{
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public class RouteResolveResult
    {
        public RouteResolveResult()
        {
            RouteValues = new ConcurrentDictionary<string, string>();
        }

        public string Url { set; get; }

        public string ControllerName
        {
            set; get;
        }


        public string ActionName { set; get; }


        public IDictionary<string,string> RouteValues
        {
            set; get;
        }


    }
}