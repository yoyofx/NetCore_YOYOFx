using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YOYO.Mvc.ActionRuntime;

namespace YOYO.Mvc.Extensions
{
    public static class ParameterInfoExtensions
    {
        public static List<ActionRuntimeParameter> ToActionParameters(this ParameterInfo[] pinfos)
        {
            return pinfos.Select(p => new ActionRuntimeParameter() { Name = p.Name , ParameterType = p.ParameterType }).ToList();
        }


        public static List<ActionRuntimeParameter> ToActionParameters(this string[] pinfos)
        {
            return pinfos.Select(p => new ActionRuntimeParameter() { Name = p, ParameterType = null }).ToList();
        }


    }
}
