using NUnit.Framework;
using System;
using YOYO.Mvc.Route;
using YOYO.Mvc;
using YOYO.Owin;

namespace YOYO.NUnitTest
{
	[TestFixture ()]
	public class RouteRoleTest
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
            Assert.AreEqual(@"p-(?<name>\w+)", segmentlist[1].Role);


            Assert.AreEqual("action", segmentlist[2].RouteNames[0]);
            Assert.AreEqual(SegmentType.Role, segmentlist[2].SegmentType);
            Assert.AreEqual(@"(?<name>\w+)", segmentlist[2].Role);


            Assert.AreEqual("id", segmentlist[3].RouteNames[0]);
            Assert.AreEqual(SegmentType.Parameter, segmentlist[3].SegmentType);



        }

        [Test]
        public void TestRouteBuilder()
        {
            IRouteBuilder builder = RouteBuilder.Builder;

            builder.Map("/api/p-{controller}/{action}/{id}");
            
            IOwinRequest request = new Mock.MockOwinRequest("/p-mycontroller/add/1","get");
            RouteResolveResult result = builder.Resolve(request);

            Assert.AreEqual("mycontroller", result.ControllerName);

            Assert.AreEqual("add", result.ActionName);

            Assert.AreEqual("add", result.RouteValues);

        }









	}
}

