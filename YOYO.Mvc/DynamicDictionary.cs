using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Mvc
{
    public class DynamicDictionary : DynamicObject
    {
        private IDictionary<string, object> _dictionary = new Dictionary<string, object>();

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {

            if (_dictionary.ContainsKey(binder.Name))
                _dictionary[binder.Name] = value;
            else
                _dictionary.Add(binder.Name,value);
            return true;
        }



        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return _dictionary.TryGetValue(binder.Name, out result);
        }

        public IDictionary<string, object> ToDictionary()
        {
            return _dictionary;
        }

    }
}
