using System;
using YOYO.AspNetCore.Mvc.Route;
using YOYO.AspNetCore.Owin;

namespace YOYO.AspNetCore.Mvc
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

		public IRouteHandler CreateRouteHandler(IOwinContext context,RouteResolveResult resolveResult)
		{
            context.Request.RouteValues = resolveResult.RouteValues;
			IRouteHandler handler = new MvcRouteHandler (resolveResult);
            return handler;
		}



	}
}

