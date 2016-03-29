using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaxZhang.EasyEntities.Persistence
{
    /// <summary>
    /// SQL命令对象，描述了SQL语句以及语句中的参数列表。
    /// </summary>
    public class Command
    {

        public string TableName { set; get; }

        public string Text { get; set; }
        public List<Parameter> Parameters { get; set; }

        public bool HasParameter
        {
            get
            {
                if (Parameters == null)
                {
                    return false;
                }
                return Parameters.Count > 0;
            }
        }

        public Command() { }

        public Command(string text)
            : this(text, null)
        {
        }

        public Command(string text, List<Parameter> parameters)
        {
            Text = text;
            Parameters = parameters;
        }

        public void AddParameter(Parameter parameter)
        {
            if (Parameters == null)
            {
                Parameters = new List<Parameter>();
            }
            Parameters.Add(parameter);
        }

        public void AddParameter(string name, object value)
        {
            AddParameter(new Parameter(name, value));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Text=" + Text);
            if (HasParameter)
            {
                sb.AppendLine("Parameters:");
                foreach (Parameter param in Parameters)
                {
                    sb.AppendLine(param.ToString());
                }
            }
            return sb.ToString();
        }
    }
}