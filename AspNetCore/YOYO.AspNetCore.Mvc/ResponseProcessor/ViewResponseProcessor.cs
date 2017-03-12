using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.AspNetCore.Owin;

namespace YOYO.AspNetCore.Mvc.ResponseProcessor
{
    internal class ViewResponseProcessor : ResponseProcessor, IResponseProcessor
    {
        internal ViewResponseProcessor(IOwinContext context) : base(context) {
            ContentType = @"text/html";
        }

        public override bool CanProcess()
        {
            string contentType = _context.Request.Headers.ContentType;
            char splitChar = ';';
            if (string.IsNullOrEmpty(contentType))
            {
                contentType = _context.Request.Headers.Accept;
                splitChar = ',';
            }

            if (string.IsNullOrEmpty(contentType))
                return false;
            //post form data
            
            var contentMimeType = contentType.Split(splitChar)[0];
            return
                 contentMimeType.Equals("text/html", StringComparison.OrdinalIgnoreCase) ||
                 contentMimeType.Equals("application/x-ms-application", StringComparison.OrdinalIgnoreCase) ||
                 contentMimeType.Equals("application/x-www-form-urlencoded", StringComparison.OrdinalIgnoreCase) ||
                 contentMimeType.Equals("multipart/form-data", StringComparison.OrdinalIgnoreCase) ;
        }

        public override string GetRawDataString(object model)
        {
            string renderedView = string.Empty;
            var view = model as View;
            if(view!=null)
            {
                string extensionName = System.IO.Path.GetExtension(view.Path);
                IViewEngine viewEngine = ViewEngineFactory.GetViewEngine(extensionName);
                try
                {
                    renderedView = viewEngine.RenderView(_context, view.Path, view.Model, view.ViewBag);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                return renderedView;
            }
            else
            {
                _context.Response.Status = Status.Is.NotFound;
                return model!=null?model.ToString():"";
            }



        }
    }
}
