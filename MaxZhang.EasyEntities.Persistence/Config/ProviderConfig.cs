using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml;
using MaxZhang.EasyEntities.Persistence.Provider;

namespace MaxZhang.EasyEntities.Persistence.Config
{
	public class ProviderConfig
	{
		static Dictionary<string, ProviderConfigItem> cachedItems;

		static ProviderConfig()
		{
			cachedItems = new Dictionary<string, ProviderConfigItem>();
			LoadConfig();
		}

		public static ProviderConfigItem GetConfigItem(string name)
		{
			if (cachedItems.ContainsKey(name))
			{
				return cachedItems[name];
			}
			throw new NotFindProviderException(name);
		}

		private static void LoadConfig()
		{
			string filePath = ConfigurationSettings.AppSettings["ProviderFilePath"];
			filePath = AppDomain.CurrentDomain.BaseDirectory + filePath;
			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException();
			}
			using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
			{
				XmlDocument doc = new XmlDocument();
				try
				{
					doc.Load(fs);
					XmlNode rootNode = doc.SelectSingleNode("providers");
					if (rootNode.HasChildNodes)
					{
						foreach (XmlNode node in rootNode.ChildNodes)
						{
							string name = node.Attributes["name"].Value;
							if (cachedItems.ContainsKey(name))
							{
								throw new Exception(String.Format("The {0} provider has existed!", name));
							}
							ProviderConfigItem item = new ProviderConfigItem
							{
								Name = name,
								Assembly = node.ChildNodes[0].InnerText,
								Provider = node.ChildNodes[1].InnerText,
								ConnString = node.ChildNodes[2].InnerText
							};
							cachedItems.Add(name, item);
						}
					}
				}
				catch (Exception e)
				{
					fs.Close();
					throw new Exception(e.Message);
				}
			}
		}
	}
}
