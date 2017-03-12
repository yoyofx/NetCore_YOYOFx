using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace YOYO.AspNetCore.Mvc.Route
{
	public class RouteSegment
	{
		public RouteSegment()
		{
			this.RouteNames = new List<string> ();
			this.SegmentType = SegmentType.Directory;
		}

		public int Index{ set; get;}
		public string Segment{ set; get;}
		public IList<string> RouteNames{ private set;get;}
		public string Role{ set; get;}

		public SegmentType SegmentType {set;get;}


        public string GetSegmentValue(string urlSegment)
        {
            if (this.SegmentType != SegmentType.Role && this.SegmentType != SegmentType.Parameter)
                throw new NotSupportedException("not role or parameter!");

            string value =null;
            var m = Regex.Match(urlSegment, this.Role);
            if(m!=null && m.Success)
            {
                value =m.Groups["name"].Value;
            }

            return value;

        }

	}
}

