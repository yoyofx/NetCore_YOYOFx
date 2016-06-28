using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendPropertyLib
{
    /// <summary>
    /// 验证信息规则对象
    /// </summary>
     [Serializable]
    public class ValiationRules
    {

        public bool isVailate{
            get{
                bool isv = true;
                foreach (var r in Rules.Values)
                {
                    if (!string.IsNullOrEmpty(r()))
                    {
                        isv = false;
                    }
                }
            return isv;
            }
        }


        private Dictionary<string, Func<string>> Rules = new Dictionary<string, Func<string>>(5);

        /// <summary>
        /// 添加验证信息规则
        /// </summary>
        /// <param name="property">要验证的属性</param>
        /// <param name="func">验证规则方法</param>
        public void Add(ExtendProperty property, Func<string> func)
        {
            lock (this)
            {
                Func<string> fn = func;
                if (Rules.TryGetValue(property.PropertyName, out fn))
                {
                    Rules[property.PropertyName] = func;
                }
                else
                {
                    Rules.Add(property.PropertyName, func);
                }
            }
        }
        /// <summary>
        /// 得到所有验证规则
        /// </summary>
        /// <returns></returns>
        public List<Func<string>> Gets()
        {
            return Rules.Values.ToList();
        }
        /// <summary>
        /// 得到指定属性名称的验证规则
        /// </summary>
        /// <param name="name">要验证的属性名</param>
        /// <returns></returns>
        public Func<string> Get(string name)
        {
            Func<string> fn = null;
            Rules.TryGetValue(name, out fn);
            return fn;
        }

    }
}
