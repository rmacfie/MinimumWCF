using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace MinimumWCF.Service
{
	public class OptionalCustomServiceHost : ServiceHost, IServiceBehavior, IInstanceProvider
	{
		readonly Calculator _calculator;

		public OptionalCustomServiceHost(string url) : base(typeof(Calculator), new Uri(url))
		{
			_calculator = new Calculator();
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
			return _calculator;
		}

		public object GetInstance(InstanceContext instanceContext, Message message)
		{
			return _calculator;
		}

		public void ReleaseInstance(InstanceContext instanceContext, object instance)
		{
		}

		#endregion
	}
}
