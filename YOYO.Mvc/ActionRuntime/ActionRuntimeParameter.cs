using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin;

namespace YOYO.Mvc.ActionRuntime
{
    public class ActionRuntimeParameter
    {
        public string Name { set; get; }
        public Type ParameterType { set; get; }


        public static List<object> GetValuesByRequest(List<ActionRuntimeParameter> parameters , IOwinRequest request)
        {
            int pindex = 0;
            List<object> pv = new List<object>();
            var routeValues = request.RouteValues.Values.ToList();
          
            foreach(var p in parameters)
            {
                var requestValue = request[p.Name];
                if(!string.IsNullOrEmpty(requestValue))
                {
                    object value = Convert.ChangeType(requestValue, p.ParameterType);
                    pv.Add(value);
                }
                else
                {
                    if (routeValues.Count >= pindex)
                    {
                        string routeValue = request.RouteValues.Values.ToList()[pindex];
                        object value = Convert.ChangeType(routeValue, p.ParameterType);
                        pv.Add(value);
                        pindex++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (parameters.Count != pv.Count)
                throw new NotSupportedException("请求地址与Action参数不匹配！");

            if (pv.Count == 0)
                pv.Add(null);

            return pv;
        }

    }
}
