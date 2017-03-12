using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.AspNetCore.Owin;

namespace YOYO.AspNetCore.Mvc.ResponseProcessor
{
    internal class TextResponseProcessor : ResponseProcessor, IResponseProcessor
    {
        internal TextResponseProcessor(IOwinContext context) : base(context) {
            ContentType = "text/plain";
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

            var contentMimeType = contentType.Split(splitChar)[0];

            return contentMimeType.Equals("text/plain", StringComparison.OrdinalIgnoreCase);
        }

        public override string GetRawDataString(object model)
        {
            return model != null ? model.ToString() : string.Empty;
        }
    }
}
