using System.ServiceModel;

namespace MinimumWCF
{
	[ServiceContract(Namespace = "http://MyOrg/MinimalWcf")]
	public interface ICalculatorService
	{
		[OperationContract]
		int Add(int number, int otherNumber);
	}
}
