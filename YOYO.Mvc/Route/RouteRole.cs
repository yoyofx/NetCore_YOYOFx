using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YOYO.Mvc.Route
{
	public class RouteRole
	{
		private static readonly string _routeRoleMatchString = @"{(?<name>\w+)}";
		private static readonly string _segmentRoleMatchString = @"(?<name>\w+)";
		private IDictionary<string, string> _routeRoleValues = new Dictionary<string, string>();
		private List<RouteSegment> _segmentList = new List<RouteSegment> ();

		private string roleString = string.Empty;

		public RouteRole(string role)
		{
            this.Method = HttpMethod.Both;
            this.ResolveRoute(role);
		}

        public HttpMethod Method
        {
            set; get;
        }


		public List<RouteSegment> Segments
		{
			get{  return _segmentList;}
		}


		public virtual void ResolveRoute(string role)
		{
            string[] segmentArray = GetUrlSegments(role);
            for (int i = 0 ; i< segmentArray.Length ; i++)
				if(!String.IsNullOrEmpty(segmentArray[i]))
					_segmentList.Add( getRouteSegment(segmentArray[i],i) );
		}

		private RouteSegment getRouteSegment(string segment , int index)
		{
			RouteSegment rs = new RouteSegment ();
			rs.Segment = segment;
			var match = Regex.Match( segment, _routeRoleMatchString, RegexOptions.IgnoreCase);
			if (match != null)
			{
		
					if (match.Success) {
						string value = match.Groups["name"].Value.ToLower();
						if (value == "controller" || value == "action") {
							rs.SegmentType = SegmentType.Role;
							rs.RouteNames.Add (value);
						}
						else {
							rs.SegmentType = SegmentType.Parameter;
							rs.RouteNames.Add (value);
						}
					}
				
			}

            setSegmentRole(rs);

            return rs;
		}

        private void setSegmentRole(RouteSegment segment)
        {
            if(segment.SegmentType == SegmentType.Role)
            {
                StringBuilder segmentRoleBuilder = new StringBuilder(segment.Segment) ;

                foreach(var routeName in segment.RouteNames)
                {
                    string oldRoleName = string.Format("{{{0}}}",routeName);
                    segmentRoleBuilder.Replace(oldRoleName, _segmentRoleMatchString);
                }

                segment.Role = segmentRoleBuilder.ToString();

            }

        }


       public static string[] GetUrlSegments(string roleUri)
        {
            string[] nullorqueryString = roleUri.Split('?');
            string roleStr = nullorqueryString.Length > 1 ? nullorqueryString[0] : roleUri;  //split querystring , such as "?name=1" 
            string[] segmentArray = roleStr.Split('/');

            return segmentArray;
        }



	}
}
