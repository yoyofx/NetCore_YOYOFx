using System;
using System.Collections.Generic;

namespace YOYO.Mvc.Route
{
	public class RouteSegment
	{
		public RouteSegment()
		{
			this.RouteNames = new List<string> ();
			this.SegmentType = SegmentType.Directory;
		}

		public uint Index{ set; get;}
		public string Segment{ set; get;}
		public IList<string> RouteNames{ private set;get;}
		public string Role{ set; get;}

		public SegmentType SegmentType {set;get;}
	}
}

