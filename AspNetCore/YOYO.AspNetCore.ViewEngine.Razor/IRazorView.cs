using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YOYO.AspNetCore.ViewEngine.Razor
{
    public interface IRazorView
    {
        RazorViewTemplate Template { get; }

        void SetContext(RenderTemplateContext context);

        void Render();

    }
}
