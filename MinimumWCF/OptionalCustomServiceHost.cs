using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace MinimumWCF
{
	public class OptionalCustomServiceHost : ServiceHost, IServiceBehavior, IInstanceProvider
	{
		readonly CalculatorServiceImpl _calculatorServiceImpl;

		public OptionalCustomServiceHost(string url) : base(typeof(CalculatorServiceImpl), new Uri(url))
		{
			_calculatorServiceImpl = new CalculatorServiceImpl();
		}


		#region Implementation of IServiceBehavior

		public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
		{
		}

		public void AddBindingParameters(
			ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
			BindingParameterCollection bindingParameters)
		{
		}

		public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
		{
			foreach (var endpointDispatcher in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>().SelectMany(x => x.Endpoints))
			{
				endpointDispatcher.DispatchRuntime.InstanceProvider = this;
			}
		}

		#endregion


		#region Implementation of IInstanceProvider

		public object GetInstance(InstanceContext instanceContext)
		{
			return _calculatorServiceImpl;
		}

		public object GetInstance(InstanceContext instanceContext, Message message)
		{
			return _calculatorServiceImpl;
		}

		public void ReleaseInstance(InstanceContext instanceContext, object instance)
		{
		}

		#endregion
	}
}
