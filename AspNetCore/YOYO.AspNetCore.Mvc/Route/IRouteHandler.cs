using System;
using System.Threading;
using System.Threading.Tasks;
using YOYO.Mvc.Route;
using YOYO.Owin;

namespace YOYO.Mvc
{
	public interface IRouteHandler
	{
		Task  ProcessAsync(IOwinContext context,CancellationToken cancellationToken);
	}
}

