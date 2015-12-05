using System;
using YOYO.Mvc.Route;

namespace YOYO.Mvc
{
	public class RouteHandlerFactory
	{
		private static readonly object lockObject = new object();
		private static RouteHandlerFactory _factory;
		public static RouteHandlerFactory Default
		{
			get
			{
				lock (lockObject)
				{
					if (_factory == null)
					{
						_factory = new RouteHandlerFactory();
					}

					return _factory;

				}
			}
		}

		public IRouteHandler CreateRouteHandler(RouteResolveResult resolveResult)
		{
			return new MvcRouteHandler ();
		}



	}
}

