using NUnit.Framework;
using System;
using YOYOFx.Mvc.Route;

namespace YOYO.NUnitTest
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase ()
		{
			RouteRole role = new RouteRole ("/{controller}/{action}/id");
			role.GetRouteValues (null);


		}
	}
}

