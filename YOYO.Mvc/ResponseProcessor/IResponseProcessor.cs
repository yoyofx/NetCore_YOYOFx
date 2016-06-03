using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin;

namespace YOYO.Mvc.ResponseProcessor
{
    internal interface IResponseProcessor
    {
        bool CanProcess();

        Task ProcessAsync(object model);

      

    }
}
