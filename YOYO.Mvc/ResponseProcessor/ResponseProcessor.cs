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
        protected string ContentType { set; get; }

        protected IOwinContext _context;
        internal ResponseProcessor(IOwinContext context)
        {
            _context = context;
        }

        public abstract bool CanProcess();


        public async void Process(object model)
        {
            string rawData = GetRawDataString(model);
          
            if (!string.IsNullOrEmpty(rawData))
            {
              _context.Response.Status = Status.Is.OK;
            }
            else
            {
                _context.Response.Status = Status.Is.NotFound;
            }
            _context.Response.Headers.ContentType = this.ContentType;
            await _context.Response.WriteAsync(rawData);
        }

        public abstract string GetRawDataString(object model);


    }
}
