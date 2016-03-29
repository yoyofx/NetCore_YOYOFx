using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MaxZhang.EasyEntities.Persistence.SqlMap
{
    public class SqlMapParameter
    {
        public string Name { set; get; }
        public object Value { set; get; }
        public Type Type { set; get; }
        public ParameterDirection Direction { set; get; }
    }
}
