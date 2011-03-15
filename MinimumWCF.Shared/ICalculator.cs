using System.ServiceModel;

namespace MinimumWCF.Shared
{
	[ServiceContract(Namespace = "http://MyOrg/MinimalWcf")]
	public interface ICalculator
	{
		[OperationContract]
		int Add(int number, int otherNumber);
	}
}
