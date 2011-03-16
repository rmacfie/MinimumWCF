using System;
using System.ServiceModel;

namespace MinimumWCF.ConsoleServiceHost
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//using (var calculatorHost = new OptionalCustomServiceHost("http://localhost:12345/"))
			using (var calculatorHost = new ServiceHost(typeof(CalculatorServiceImpl), new Uri("http://localhost:12345/")))
			{
				calculatorHost.Open();

				Console.WriteLine("Calculator Server is started");
				Console.WriteLine("Press <Enter> at any time to close.");
				Console.ReadLine();

				calculatorHost.Close();
			}
		}
	}
}
