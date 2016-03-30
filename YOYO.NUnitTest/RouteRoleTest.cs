using NUnit.Framework;
using System;
using YOYO.Mvc.Route;
using YOYO.Mvc;
using YOYO.Owin;
using MaxZhang.EasyEntities.Persistence;
using MaxZhang.EasyEntities.Persistence.Provider;
using paipaiyuan.fx.db;

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



//
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

            builder.Map("/api/p-{controller}/{action}/{id}/");



            IOwinRequest request = new Mock.MockOwinRequest("/api/p-mycontroller/add/1/2/3/4","get");
            RouteResolveResult result = builder.Resolve(request);

            Assert.AreEqual("mycontroller", result.ControllerName);

            Assert.AreEqual("add", result.ActionName);

            Assert.AreEqual("1", result.RouteValues["id"]);

            Assert.AreEqual("2", result.RouteValues["p0"]);

            Assert.AreEqual("3", result.RouteValues["p1"]);

            Assert.AreEqual("4", result.RouteValues["p2"]);

			builder.Map ("/Home/Index", "v_Home", "v_Index");
			IOwinRequest request1 = new Mock.MockOwinRequest("/Home/Index/1","get");
			RouteResolveResult result1 = builder.Resolve(request1);
			Assert.AreEqual("v_Home", result1.ControllerName);
			Assert.AreEqual("v_Index", result1.ActionName);
			Assert.AreEqual("1", result1.RouteValues["p0"]);

			builder.Map (role:"/{controller}/Index", defaultActionName:"v_Index" );

			IOwinRequest request2 = new Mock.MockOwinRequest("/Acount/Index/1","get");
			RouteResolveResult result2 = builder.Resolve(request2);
			Assert.AreEqual("Acount", result2.ControllerName);
			Assert.AreEqual("v_Index", result2.ActionName);
			Assert.AreEqual("1", result2.RouteValues["p0"]);


        }




		[Test]
		public void TestORM()
		{
			Console.WriteLine ("ORM test start!");
			String mysqlStr = "Database=paipaiyuan;Data Source=127.0.0.1;User Id=root;Password=123456;pooling=false;CharSet=utf8;port=3306";
			var provider = new MySQLProvider (mysqlStr);
			using (var session = new DbSession (provider)) {
				
				var video = new ppy_video (){  Url = "15555555", State = 2, Orderid = 5, Uploadtime = 1453446120};

				session.InsertTransaction (video);
				session.SubmitChanges ();

				var query = session.CreateQuery<ppy_video> ();
				var list = query.Where( v=>v.Id <= 215 ).ToList ();
				foreach (ppy_video q in list)
					Console.WriteLine (q.Url);

			}

			Assert.AreEqual(1, 1);
		}







	}
}
