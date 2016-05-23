using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YOYO.Mvc;

namespace YOYO.AspNetCore.ViewEngine.Razor
{

    public abstract class RazorViewTemplate
    {
        public string Layout { get; set; }

        public Func<string> RenderBody { get; set; }
        public string Path { get; internal set; }
        public string Result { get { return Writer.ToString(); } }

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

        public abstract void SetModel(object model, DynamicDictionary viewbag = null);


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