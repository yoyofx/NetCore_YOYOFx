using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YOYO.AspNetCore.ViewEngine.Razor
{
    public interface IRazorView
    {
        string Content { get; }
        RazorViewTemplate Template { get; }
        void Render(TemplateContext context);

    }
}
