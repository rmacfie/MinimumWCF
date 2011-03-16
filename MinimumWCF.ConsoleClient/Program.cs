using System;

namespace MinimumWCF.ConsoleClient
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to the Calculator client.");
			var sum = 0;

			while (true)
			{
				Console.WriteLine("Current sum: {0}. Please type a new number and press <enter> to calculate.", sum);
				var input = int.Parse(Console.ReadLine());
				Console.Write("Calculating {0} + {1}", sum, input);


				using (var calculatorProxy = new CalculatorServiceProxy("http://localhost:12345/"))
				{
					sum = calculatorProxy.Add(input, sum);
				}


				Console.WriteLine(" = {0}", sum);
			}
		}
	}
}
