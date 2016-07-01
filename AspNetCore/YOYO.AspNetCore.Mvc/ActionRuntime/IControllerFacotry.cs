using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Mvc.ActionRuntime
{
    public interface IControllerFacotry
    {
        Controller CreateController(Type controllerType, IServiceProvider serverProvider);


    }
}
