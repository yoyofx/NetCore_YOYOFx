using System;
using System.Threading;
using System.Threading.Tasks;
using YOYO.Mvc.Route;
using YOYO.Owin;

namespace YOYO.Mvc
{
	public interface IRouteHandler
	{
        void SetRouteResult(RouteResolveResult result);
		Task  Process(IOwinContext context,CancellationToken cancellationToken);
	}
}

