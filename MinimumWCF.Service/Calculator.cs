using System;
using MinimumWCF.Shared;

namespace MinimumWCF.Service
{
	public class Calculator : ICalculator
	{
		#region ICalculator Members

		public int Add(int number, int otherNumber)
		{
			var sum = number + otherNumber;

			Console.WriteLine("Calculated {0} + {1} = {2}.", number, otherNumber, sum);

			return sum;
		}

		#endregion
	}
}
