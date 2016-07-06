using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace YOYO.Mvc.ActionRuntime
{
    public class DefaultControllerFactory : IControllerFacotry
    {

        public Controller CreateController(Type controllerType , IServiceProvider serverProvider)
        {
            Controller activeController = null;

            activeController = (Controller)ActivatorUtilities.CreateInstance(serverProvider, controllerType);

            return activeController;
        }
    }
}
