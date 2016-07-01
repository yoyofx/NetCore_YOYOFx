using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin;
using Newtonsoft.Json;

namespace YOYO.Mvc.ResponseProcessor
{
    internal class JsonResponseProcessor : ResponseProcessor , IResponseProcessor
    {
        internal JsonResponseProcessor(IOwinContext context):base(context)
        {
            ContentType = @"application/json";
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

            return contentMimeType.Equals("application/json", StringComparison.OrdinalIgnoreCase) ||
            contentMimeType.StartsWith("application/json-", StringComparison.OrdinalIgnoreCase) ||
            contentMimeType.Equals("text/json", StringComparison.OrdinalIgnoreCase) ||
            (contentMimeType.StartsWith("application/vnd", StringComparison.OrdinalIgnoreCase) &&
            contentMimeType.EndsWith("+json", StringComparison.OrdinalIgnoreCase));
        }

        public override string GetRawDataString(object model)
        {
            return JsonConvert.SerializeObject(model);
        }
    }
}
