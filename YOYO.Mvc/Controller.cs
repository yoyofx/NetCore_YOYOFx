using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin;

namespace YOYO.Mvc
{
    public class Controller
    {
        protected IOwinContext Context { set; get; }

        protected View View(string mapPath , dynamic model)
        {
            return new View(mapPath) {
                ControllerName = this.GetType().Name , Model = model  };
        }

    }
}
