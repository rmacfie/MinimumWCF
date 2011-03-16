using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace MinimumWCF
{
	public class CalculatorServiceProxy : ClientBase<ICalculatorService>, ICalculatorService
	{
		public CalculatorServiceProxy(string url) : base(GetBinding(url), GetEndpointAddress(url))
		{
		}


		#region ICalculatorService Members

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
