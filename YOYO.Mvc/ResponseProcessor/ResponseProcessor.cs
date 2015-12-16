using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin;


namespace YOYO.Mvc.ResponseProcessor
{
    internal abstract class ResponseProcessor : IResponseProcessor
    {
        protected IOwinContext _context;
        internal ResponseProcessor(IOwinContext context)
        {
            _context = context;
        }

        public abstract bool CanProcess();


        public void Process(object model)
        {
            string rawData = GetRawDataString(model);

            _context.Response.Status = Status.Is.OK;

            _context.Response.Write(rawData);
        }

        public abstract string GetRawDataString(object model);


    }
}
