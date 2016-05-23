using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YOYO.AspNetCore.ViewEngine.Razor
{
    [HtmlTargetElement(tag:"mydiv")]
    public class MyTagHelper : TagHelper
    {
        [HtmlAttributeName("mname")]
        public string Name { get; set; }


        public override void Init(TagHelperContext context)
        {
            base.Init(context);
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

           


        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            return base.ProcessAsync(context, output);
        }

    }
}
