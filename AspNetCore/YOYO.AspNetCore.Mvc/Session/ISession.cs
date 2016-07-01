using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Mvc.Session
{
    public interface ISession
    {
        object this[string key] { set; get; }
        string ID { set; get; }

    }
}
