using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin;

namespace YOYO.Mvc.ResponseProcessor
{
    internal class ViewResponseProcessor : ResponseProcessor, IResponseProcessor
    {
        internal ViewResponseProcessor(IOwinContext context) : base(context) { }

        public override bool CanProcess()
        {
            string contentType = _context.Request.Headers.ContentType;
            return string.IsNullOrEmpty(contentType);
        }

        public override string GetRawDataString(object model)
        {
            var view = model as View;
            if(view!=null)
            {
                string extensionName = System.IO.Path.GetExtension(view.Path);
                IViewEngine viewEngine = ViewEngineFactory.GetViewEngine(extensionName);
               return viewEngine.RenderView(_context, view.Path, view.Model, view.ViewBag);

            }
            else
            {
                return "";
            }



        }
    }
}
