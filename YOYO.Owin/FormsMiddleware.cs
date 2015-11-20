using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YOYO.Owin
{
    using MiddlewareFunc = Func<IDictionary<string, object>, Func<IDictionary<string, object>, Task>, Task>;

    public static class FormsMiddleware
    {
        private static readonly Regex MultipartRegex = new Regex(@"multipart/form-data;\s*boundary=(""?)(\w+)\1\s*$",
                                                                 RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static MiddlewareFunc ParseFormData {
            get {
                return (env, next) => {
							IOwinContext owinContext = new OwinContext(env);
                           //check for POST?
                           var contentType = owinContext.Request.Headers.ContentType;
                           if (contentType == FormData.GetUrlEncodedContentType()) {
                               owinContext.Request.FormData = FormData.ParseUrlEncoded(owinContext.Request.Body)
                                                                      .Result;
                           }
                           else {
                               var match = MultipartRegex.Match(contentType);
                               if (match.Success) {
                                   owinContext.Request.FormData = FormData.ParseMultipart(owinContext.Request.Body, match.Groups[2].Value)
                                                                          .Result;
                               }
                           }
                           return next(env);
                       };
            }
        }
    }
}