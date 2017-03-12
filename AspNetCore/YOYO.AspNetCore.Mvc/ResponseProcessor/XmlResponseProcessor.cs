using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using YOYO.AspNetCore.Owin;

namespace YOYO.AspNetCore.Mvc.ResponseProcessor
{
   internal class XmlResponseProcessor : ResponseProcessor , IResponseProcessor
    {
        internal XmlResponseProcessor(IOwinContext context):base(context)
        {
            ContentType = "application/xml";
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

            return contentMimeType.Equals("application/xml", StringComparison.OrdinalIgnoreCase) ||
            contentMimeType.Equals("text/xml", StringComparison.OrdinalIgnoreCase) ||
            (contentMimeType.StartsWith("application/vnd", StringComparison.OrdinalIgnoreCase) &&
            contentMimeType.EndsWith("+xml", StringComparison.OrdinalIgnoreCase));
        }

        public override string GetRawDataString(object model)
        {
            if (model == null) return string.Empty;

            using (StringWriter stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(model.GetType());
                serializer.Serialize(stringwriter, model);
                return stringwriter.ToString();
            }
        }
    }
}
