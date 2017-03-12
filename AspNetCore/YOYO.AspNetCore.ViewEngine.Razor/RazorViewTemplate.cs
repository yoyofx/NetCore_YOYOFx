using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YOYO.AspNetCore.Mvc;

namespace YOYO.AspNetCore.ViewEngine.Razor
{

    public abstract class RazorViewTemplate
    {
        public string Layout { get; set; }
        public Func<string> RenderBody { set; get; }

        public string Path { get; internal set; }
        public string Result { get { return Writer.ToString(); } }

        public dynamic ViewBag { set; get; }

        protected RazorViewTemplate()
        {
        }

        public TextWriter Writer
        {
            get
            {
                if (writer == null)
                {
                    writer = new StringWriter();
                }
                return writer;
            }
            set
            {
                writer = value;
            }
        }

        private TextWriter writer;

        public void Clear()
        {
            Writer.Flush();
        }

        public virtual void SetModel(object model, DynamicDictionary viewbag = null)
        {
            if (viewbag != null)
                setViewBag(viewbag);
            else
                setViewBag(new DynamicDictionary());
        }


        public void setViewBag(DynamicDictionary viewbag)
        {
            this.ViewBag = viewbag;
        }

        public abstract Task Execute();

        public void Write(object @object)
        {
            if (@object == null)
            {
                return;
            }
            Writer.Write(@object);
        }







        public void WriteLiteral(string @string)
        {
            if (@string == null)
            {
                return;
            }
            Writer.Write(@string);
        }

        public static void WriteLiteralTo(TextWriter writer, string literal)
        {
            if (literal == null)
            {
                return;
            }
            writer.Write(literal);
        }

        public static void WriteTo(TextWriter writer, object obj)
        {
            if (obj == null)
            {
                return;
            }
            writer.Write(obj);
        }

    }

}