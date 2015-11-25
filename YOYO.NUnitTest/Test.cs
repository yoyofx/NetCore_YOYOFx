using NUnit.Framework;
using System;
using YOYO.Mvc.Route;

namespace YOYO.NUnitTest
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase ()
		{
			RouteRole role = new RouteRole ("/{controller}/{action}/id");
			var segmentlist = role.Segments;

		}
	}
}

