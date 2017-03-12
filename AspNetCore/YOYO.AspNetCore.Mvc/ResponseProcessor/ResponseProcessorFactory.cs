using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.AspNetCore.Owin;

namespace YOYO.AspNetCore.Mvc.ResponseProcessor
{
    internal class ResponseProcessorFactory
    {
        internal static IResponseProcessor GetResponseProcessor(IOwinContext context)
        {
           IResponseProcessor responseProcessor = null;

           //get formater
           var createProcessors =  CreateProcessorsFunc();
           var processorList = createProcessors(context);
           foreach(var processor in processorList)
            {
                if(processor.CanProcess())
                {
                    responseProcessor = processor;
                    break;
                }
            
            }
            return responseProcessor;

        }

        /// <summary>
        /// get formater,一般只处理
        /// </summary>
        /// <returns></returns>
        private static Func<IOwinContext,List<IResponseProcessor>> CreateProcessorsFunc()
        {
            return _ =>
            {
                return new List<IResponseProcessor>()
                {
                    new JsonResponseProcessor( _ ),
                    new XmlResponseProcessor( _ ),
                    new TextResponseProcessor( _ ),
                    new ViewResponseProcessor( _ )
                };
            };
        }


    }
}
