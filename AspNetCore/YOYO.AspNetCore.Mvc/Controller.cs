using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.AspNetCore.Mvc.Session;
using YOYO.AspNetCore.Owin;

namespace YOYO.AspNetCore.Mvc
{
    public class Controller
    {
        protected IOwinContext Context { set; get; }
        internal void SetHttpContext(IOwinContext context)
        {
            this.Context = context;
        }
        private DynamicDictionary _viewBag = new DynamicDictionary();
        protected dynamic ViewBag {
            get
            {
                return _viewBag;
            }
        }


        protected View View(string mapPath , dynamic model)
        {
            return new View(mapPath) {
                ControllerName = this.GetType().Name , Model = model , ViewBag = this._viewBag
            };
        }


        protected View View(string mapPath)
        {

            return new View(mapPath) { ControllerName = this.GetType().Name, Model = null , ViewBag = _viewBag };

        }


        protected dynamic Redirect(string location)
        {
            this.Context.Response.Redirect(location);
            return null;
        }

        protected ISession Session {
            get {
                return Context.Items["session"] as ISession;
            }
        }
    }
}
