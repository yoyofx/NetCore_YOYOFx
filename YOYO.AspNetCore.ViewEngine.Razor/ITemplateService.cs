using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YOYO.AspNetCore.ViewEngine.Razor
{
    public interface ITemplateService
    {

        IRazorView GetTemplate(string name, Type modelType);

    }
}
