using System;

namespace MaxZhang.EasyEntities.Persistence.Provider
{
	public class ProviderException : Exception
	{
		public ProviderException()
			: this("provider")
		{
		}

		public ProviderException(string message)
			: base(message)
		{
		}

		public ProviderException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}

	public class NotFindProviderException : ProviderException
	{
		public NotFindProviderException()
			: this("Not find the data provider instance!")
		{
		}

		public NotFindProviderException(string message)
			: base(message)
		{
		}

		public NotFindProviderException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}

	public class NotMatchProviderException : ProviderException
	{
		public NotMatchProviderException()
			: this("The data provider is not matched!")
		{
		}

		public NotMatchProviderException(string message)
			: base(message)
		{
		}

		public NotMatchProviderException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
