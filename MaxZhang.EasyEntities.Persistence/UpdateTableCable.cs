using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace MaxZhang.EasyEntities.Persistence
{
    /// <summary>
    /// 更新表时存储记录的旧属性值
    /// </summary>
    internal class UpdateTableCable
    {
        private static Dictionary<Type, string> cable;

        static UpdateTableCable()
        {
            cable = new Dictionary<Type, string>();
        }

        public static object Get(Type type)
        {
           
            string strObj = null;
            if (cable.TryGetValue(type, out strObj))
            {

                object result = ObjectDeserialize(strObj,type);
                cable.Remove(type);
                return result;
            }
            return null;
        }

        public static void Set(Type type, object obj)
        {
            string strObj = ObjectSerializer(obj);

            if (!cable.Keys.Any(t => t == type))
                cable.Add(type, strObj);
            else
                cable[type] = strObj;
        }


        internal static string ObjectSerializer(object obj)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                using (TextWriter tw = new StringWriter(sb))
                {
                    serializer.Serialize(tw, obj);
                }
            }
            catch
            {
            }
            return sb.ToString();
        }

        internal static object ObjectDeserialize(string strObj, Type type)
        {
            object obj = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(type);
                using (StringReader sr = new StringReader(strObj))
                {
                    obj = serializer.Deserialize((TextReader)sr);
                }
            }
            catch
            { }
            return obj;
        }


    }
}
