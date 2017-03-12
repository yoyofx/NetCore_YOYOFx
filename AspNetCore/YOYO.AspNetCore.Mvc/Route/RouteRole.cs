using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YOYO.AspNetCore.Mvc.Extensions;

namespace YOYO.AspNetCore.Mvc.Route
{
    public class RouteRole
    {
        private static readonly string _routeRoleMatchString = @"{(?<name>\w+)}";
        private static readonly string _segmentRoleMatchString = @"(?<name>\w+)";
        private List<RouteSegment> _segmentList = new List<RouteSegment>();


        public RouteRole(string role, string defaultControllerName = null, string defaultActionName = null)
        {
            this.DefalutAction = defaultActionName;
            this.DefaultController = defaultControllerName;
            this.Method = HttpMethod.Both;
            this.ResolveRoute(role);
        }

        public HttpMethod Method
        {
            set; get;
        }



        public string DefaultController { set; get; }
        public string DefalutAction { set; get; }


        public List<RouteSegment> Segments
        {
            get { return _segmentList; }
        }


        public virtual void ResolveRoute(string role)
        {
            var segmentArray = role.GetUrlSegments();
            for (int i = 0; i < segmentArray.Count; i++)
                _segmentList.Add(getRouteSegment(segmentArray[i], i));
        }

        private RouteSegment getRouteSegment(string segment, int index)
        {
            RouteSegment rs = new RouteSegment();
            rs.Index = index;
            rs.Segment = segment;
            var match = Regex.Match(segment, _routeRoleMatchString, RegexOptions.IgnoreCase);
            if (match != null)
            {

                if (match.Success)
                {
                    string value = match.Groups["name"].Value.ToLower();
                    if (value == "controller" || value == "action")
                    {
                        rs.SegmentType = SegmentType.Role;
                        rs.RouteNames.Add(value);
                    }
                    else
                    {
                        rs.SegmentType = SegmentType.Parameter;
                        rs.RouteNames.Add(value);
                    }
                }

            }

            setSegmentRole(rs);

            return rs;
        }

        private void setSegmentRole(RouteSegment segment)
        {
            if (segment.SegmentType == SegmentType.Role)
            {
                StringBuilder segmentRoleBuilder = new StringBuilder(segment.Segment);

                foreach (var routeName in segment.RouteNames)
                {
                    string oldRoleName = string.Format("{{{0}}}", routeName);
                    segmentRoleBuilder.Replace(oldRoleName, _segmentRoleMatchString);
                }

                segment.Role = segmentRoleBuilder.ToString();

            }

        }











    }
}
