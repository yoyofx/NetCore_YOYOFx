using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YOYO.AspNetCore.Owin;
using YOYO.AspNetCore.Mvc.Extensions;

namespace YOYO.AspNetCore.Mvc.ActionRuntime
{
    public class ActionRuntimeParameter
    {
        public string Name { set; get; }
        public Type ParameterType { set; get; }


        public static List<object> GetValuesByRequest(List<ActionRuntimeParameter> parameters , IOwinRequest request)
        {
            int pindex = 0;
            //返回值
            List<object> pv = new List<object>();
            var routeValues = request.RouteValues.Values.ToList();
          
            foreach(var p in parameters)
            {
                //get type default value
                object pvItem = p.ParameterType.GetTypeDefaultValue();

                var requestValue = request[p.Name];
                if(!string.IsNullOrEmpty(requestValue))
                    pvItem = Convert.ChangeType(requestValue, p.ParameterType);
                else
                {
                    if (routeValues.Count > pindex){
                        string routeValue = request.RouteValues.Values.ToList()[pindex];
                        pvItem = Convert.ChangeType(routeValue, p.ParameterType);
                        pindex++;
                    }
                }

                pv.Add(pvItem);
               
            }

            if (parameters.Count != pv.Count)
                throw new NotSupportedException("请求地址与Action参数不匹配！");

            if (pv.Count == 0)
                pv.Add(null);

            return pv;
        }

    }
}
