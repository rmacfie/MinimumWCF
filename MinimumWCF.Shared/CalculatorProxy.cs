using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace MinimumWCF.Shared
{
	public class CalculatorProxy : ClientBase<ICalculator>, ICalculator
	{
		public CalculatorProxy(string url) : base(GetBinding(url), GetEndpointAddress(url))
		{
		}


		#region ICalculator Members

		public int Add(int number, int otherNumber)
		{
			return Channel.Add(number, otherNumber);
		}

		#endregion


		static EndpointAddress GetEndpointAddress(string url)
		{
			return new EndpointAddress(url);
		}

		static Binding GetBinding(string url)
		{
			if (url.StartsWith("http://"))
			{
				return new BasicHttpBinding(BasicHttpSecurityMode.None);
			}

			throw new ArgumentException("Could not determine binding type from the given URL.", "url");
		}
	}
}
