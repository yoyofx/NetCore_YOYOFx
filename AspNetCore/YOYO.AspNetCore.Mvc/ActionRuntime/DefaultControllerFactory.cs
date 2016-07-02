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

            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var constructors = controllerType.GetConstructors(flags);
            if(constructors.Length > 1 )
            {
                var ctorInfo = constructors.Where(constructor => 
                                                                            constructor.GetParameters().Length > 0).First();

                var ctorParamList = ctorInfo.GetParameters();
                var iocParamtersArray = ctorParamList.Select(cp=> serverProvider.GetService( cp.ParameterType ) ).ToArray();
                activeController = (Controller)Activator.CreateInstance(controllerType,iocParamtersArray);
            }
            else
            {
                activeController = (Controller)Activator.CreateInstance(controllerType);
            }
          
            

            return activeController;
        }
    }
}
