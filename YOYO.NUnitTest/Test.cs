using NUnit.Framework;
using System;
using YOYO.Mvc.Route;
using YOYO.Mvc;

namespace YOYO.NUnitTest
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestRouteRoleForSegment ()
		{
			RouteRole role = new RouteRole ("/api/p-{controller}/{action}/{id}");
			var segmentlist = role.Segments;
            Assert.AreEqual("api", segmentlist[0].Segment);
            Assert.AreEqual(SegmentType.Directory, segmentlist[0].SegmentType);


            Assert.AreEqual("controller", segmentlist[1].RouteNames[0]);
            Assert.AreEqual(SegmentType.Role, segmentlist[1].SegmentType);

            Assert.AreEqual("action", segmentlist[2].RouteNames[0]);
            Assert.AreEqual(SegmentType.Role, segmentlist[2].SegmentType);

            Assert.AreEqual("id", segmentlist[3].RouteNames[0]);
            Assert.AreEqual(SegmentType.Parameter, segmentlist[3].SegmentType);

        }









	}
}

