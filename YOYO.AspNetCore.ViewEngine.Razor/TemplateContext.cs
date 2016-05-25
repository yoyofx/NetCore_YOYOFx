using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YOYO.Mvc;

namespace YOYO.AspNetCore.ViewEngine.Razor
{
    public class TemplateContext
    {
        public TemplateContext()
        {
            IsRenderLayout = false;
            Writer = new StringWriter();
        }

        public Type ModelType { set; get; }
        public object Model { set; get; }

        public DynamicDictionary ViewBag { set; get; }


        public bool IsRenderLayout { set; get; }


        public string Result { get { return Writer.ToString(); } }


        public TextWriter Writer {  set; get; }

    }
}
