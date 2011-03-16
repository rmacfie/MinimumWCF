using System;

namespace MinimumWCF.ConsoleClient
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var sum = 0;
			string serviceUrl;

			Console.WriteLine("Welcome to the Calculator client.");
			Console.Write("Use [w]eb or [c]onsole endpoint? ");
			switch (Console.ReadLine())
			{
				case "w":
					serviceUrl = "http://localhost:51234/Calculator.svc";
					break;
				case "c":
					serviceUrl = "http://localhost:12345/";
					break;
				default:
					Console.WriteLine("Not a valid key.");
					Main(null);
					return;
			}

			while (true)
			{
				Console.WriteLine("Current sum: {0}. Please type a new number.", sum);
				var input = int.Parse(Console.ReadLine());
				Console.Write("Connecting to '{0}' to calculate {1} + {2}", serviceUrl, sum, input);

				using (var calculatorProxy = new CalculatorServiceProxy(serviceUrl))
				{
					sum = calculatorProxy.Add(input, sum);
				}

				Console.WriteLine(" = {0}", sum);
			}
		}
	}
}
