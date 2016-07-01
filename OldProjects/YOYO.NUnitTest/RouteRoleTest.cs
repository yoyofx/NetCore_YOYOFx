using NUnit.Framework;
using System;
using MaxZhang.EasyEntities.Persistence;
using MaxZhang.EasyEntities.Persistence.Provider;
using paipaiyuan.fx.db;

namespace YOYO.NUnitTest
{
	[TestFixture ()]
	public class RouteRoleTest
    {

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
