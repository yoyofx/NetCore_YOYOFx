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
            this.MapRouteValues(role);
        }

		public List<RouteSegment> Segments
		{
			get{  return _segmentList;}
		}


        public virtual void MapRouteValues(string role)
        {
			string[] nullorqueryString = role.Split ('?');
			string roleStr  = nullorqueryString.Length > 1 ? nullorqueryString[0] : role;
			string[] segmentArray = roleStr.Split ('/');

			for(int i = 0 ; i< segmentArray.Length ; i++)
				_segmentList.Add( getRouteSegment(segmentArray[i],i) );

        
        }

		private RouteSegment getRouteSegment(string segment , int index)
		{
			RouteSegment rs = new RouteSegment ();
			rs.Segment = segment;
			var matches = Regex.Matches( segment, _routeRoleMatchString, RegexOptions.IgnoreCase);
			if (matches != null)
			{
				foreach (Match m in matches)
				{
					if (m.Success) {
						string value = m.Groups["name"].Value.ToLower();
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
			}
			return rs;
		}



        public virtual bool IsMatch(string url)
        {


            return true;
        }

        public IDictionary<string, string> GetRouteValues(string url)
        {
           string[] sp = url.Split('\\');
            

            return null;
        }




    }
}
