using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorEngine.Templating;
using RazorEngine.Text;
using YOYO.Mvc;

namespace YOYO.ViewEngine.RazorViewEngine
{
    public class MyHtmlHelper
    {
        public IEncodedString Raw(string rawString)
        {
            return new RawString(rawString);
        }
    }

    public  class RazorEngineTemplate<T> : TemplateBase<T>
    {
        public RazorEngineTemplate()
        {
            Html = new MyHtmlHelper();
        }



        public MyHtmlHelper Html { get; set; }
    }
}
