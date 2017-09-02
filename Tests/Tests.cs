//using System;
//using Xunit;
//using YOYO.Mvc;
//using YOYO.Mvc.Route;
//using YOYO.Owin;

//namespace Tests
//{
//    public class Tests
//    {
//        [Fact]
//        public void Test1() 
//        {
//            Assert.True(true); 
//        }


//        [Fact]
//        public void TestRouteRoleForSegment()
//        {
//            RouteRole role = new RouteRole("/api/p-{controller}/{action}/{id}");
//            var segmentlist = role.Segments;
//            Assert.Equal("api", segmentlist[0].Segment);
//            Assert.Equal(SegmentType.Directory, segmentlist[0].SegmentType);



//            //
//            Assert.Equal("controller", segmentlist[1].RouteNames[0]);
//            Assert.Equal(SegmentType.Role, segmentlist[1].SegmentType);
//            Assert.Equal(@"p-(?<name>\w+)", segmentlist[1].Role);


//            Assert.Equal("action", segmentlist[2].RouteNames[0]);
//            Assert.Equal(SegmentType.Role, segmentlist[2].SegmentType);
//            Assert.Equal(@"(?<name>\w+)", segmentlist[2].Role);


//            Assert.Equal("id", segmentlist[3].RouteNames[0]);
//            Assert.Equal(SegmentType.Parameter, segmentlist[3].SegmentType);



//        }

//        [Fact]
//        public void TestRouteBuilder()
//        {
//            IRouteBuilder builder = RouteBuilder.Builder;

//            builder.Map("/api/p-{controller}/{action}/{id}/");



//            IOwinRequest request = new MockOwinRequest("/api/p-mycontroller/add/1/2/3/4", "get");
//            RouteResolveResult result = builder.Resolve(request);

//            Assert.Equal("mycontroller", result.ControllerName);

//            Assert.Equal("add", result.ActionName);

//            Assert.Equal("1", result.RouteValues["id"]);

//            Assert.Equal("2", result.RouteValues["p0"]);

//            Assert.Equal("3", result.RouteValues["p1"]);

//            Assert.Equal("4", result.RouteValues["p2"]);

//            builder.Map("/Home/Index", "v_Home", "v_Index");
//            IOwinRequest request1 = new MockOwinRequest("/Home/Index/1", "get");
//            RouteResolveResult result1 = builder.Resolve(request1);
//            Assert.Equal("v_Home", result1.ControllerName);
//            Assert.Equal("v_Index", result1.ActionName);
//            Assert.Equal("1", result1.RouteValues["p0"]);

//            builder.Map(role: "/{controller}/Index", defaultActionName: "v_Index");

//            IOwinRequest request2 = new MockOwinRequest("/Acount/Index/1", "get");
//            RouteResolveResult result2 = builder.Resolve(request2);
//            Assert.Equal("Acount", result2.ControllerName);
//            Assert.Equal("v_Index", result2.ActionName);
//            Assert.Equal("1", result2.RouteValues["p0"]);
                      

//        }


//    }
//}
