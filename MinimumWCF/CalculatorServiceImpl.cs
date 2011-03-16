using System;

namespace MinimumWCF
{
	public class CalculatorServiceImpl : ICalculatorService
	{
		#region ICalculatorService Members

		public int Add(int number, int otherNumber)
		{
			var sum = number + otherNumber;

			Console.WriteLine("Calculated {0} + {1} = {2}.", number, otherNumber, sum);

			return sum;
		}

		#endregion
	}
}
