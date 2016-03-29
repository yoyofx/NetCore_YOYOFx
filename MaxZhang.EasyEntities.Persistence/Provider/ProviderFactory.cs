using System;
using MaxZhang.EasyEntities.Persistence.Config;

namespace MaxZhang.EasyEntities.Persistence.Provider
{
    /// <summary>
    /// 数据库提供器工厂 ， 用于根据DP文件创建数据库提供程序
    /// </summary>
    public class ProviderFactory
    {
        const string DEFAULT_PROVIDER = "DefaultProvider";
        //static Dictionary<string, IProvider> cachedProviders;

        static ProviderFactory()
        {
            //cachedProviders = new Dictionary<string, IProvider>();
        }

        public static IDataProvider GetProvider()
        {
            return GetProvider(DEFAULT_PROVIDER);
        }

        public static IDataProvider GetProvider(string name)
        {
            //if (cachedProviders.ContainsKey(name))
            //{
            //    return cachedProviders[name];
            //}
            ProviderConfigItem item = ProviderConfig.GetConfigItem(name);
            IDataProvider provider = GetProvider(item.Assembly, item.Provider, item.ConnString);
            //cachedProviders.Add(name, provider);
            return provider;
        }

        public static IDataProvider GetProvider(string assembly, string provider, string connString)
        {
            object temp = Activator.CreateInstance(assembly, provider).Unwrap();
            if (temp == null)
            {
                throw new NotFindProviderException();
            }
            if (!(temp is IDataProvider))
            {
                throw new NotMatchProviderException();
            }
            IDataProvider instance = temp as IDataProvider;
            instance.ConnString = connString;
            return instance;
        }
    }
}