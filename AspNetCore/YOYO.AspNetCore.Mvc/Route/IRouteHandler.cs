using System;
using System.Threading;
using System.Threading.Tasks;
using YOYO.AspNetCore.Mvc.Route;
using YOYO.AspNetCore.Owin;

namespace YOYO.AspNetCore.Mvc
{
	public interface IRouteHandler
	{
		Task  ProcessAsync(IOwinContext context,CancellationToken cancellationToken);
	}
}

