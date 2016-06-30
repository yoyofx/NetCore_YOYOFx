using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Mvc.ActionRuntime
{
    public class DefaultControllerFactory : IControllerFacotry
    {

        public Controller CreateController(Type controllerType , IServiceProvider serverProvider)
        {
            


            var controller = (Controller)Activator.CreateInstance(controllerType);
            return controller;
        }
    }
}
