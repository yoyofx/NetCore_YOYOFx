namespace MaxZhang.EasyEntities.Persistence.Config
{
	public class ProviderConfigItem
	{
		public string Name { get; set; }
		public string Assembly { get; set; }
		public string Provider { get; set; }
		public string ConnString { get; set; }

		public ProviderConfigItem() { }

		public ProviderConfigItem(string name, string assembly, string provider, string connString)
		{
			Name = name;
			Assembly = assembly;
			Provider = provider;
			ConnString = connString;
		}
	}
}
