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

        private DynamicDictionary viewBag = new DynamicDictionary();
        protected dynamic ViewBag {
            get
            {
                return viewBag;
            }
        }


        protected View View(string mapPath , dynamic model)
        {
            return new View(mapPath) {
                ControllerName = this.GetType().Name , Model = model , ViewBag = this.ViewBag };
        }


        protected View View(string mapPath)
        {

            return new View(mapPath) { ControllerName = this.GetType().Name, Model = null , ViewBag = ViewBag };

        }


    }
}
