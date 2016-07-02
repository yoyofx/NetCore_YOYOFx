using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace YOYO.Mvc.ActionRuntime
{
    public class DefaultControllerFactory : IControllerFacotry
    {

        public Controller CreateController(Type controllerType , IServiceProvider serverProvider)
        {
            Controller activeController = null;

            var constructors = controllerType.GetConstructors();
            if(constructors.Length > 0 )
            {

            }
            else
            {
                activeController = (Controller)Activator.CreateInstance(controllerType);

            }
          
            

            return activeController;
        }
    }
}
