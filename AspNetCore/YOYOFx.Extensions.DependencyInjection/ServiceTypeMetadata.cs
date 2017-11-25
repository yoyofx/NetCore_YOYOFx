using System;
using System.Collections.Generic;
using System.Text;

namespace YOYOFx.Extensions.DependencyInjection
{
    public class ServiceTypeMetadata
    {
        public string Name { set; get; }

        public string NameSpace { set; get; }

        public Type ServiceType { set; get; }

        public string Description { set; get; }

        public object Configuration { set; get; }

        public TConfig GetConfig<TConfig>()
        {
            return (TConfig)Configuration;
        }

    }
}
