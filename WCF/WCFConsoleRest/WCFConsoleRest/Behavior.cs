using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace WCFConsoleRest
{
    class ServiceBehavior : IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            Console.WriteLine($"{nameof(ServiceBehavior)}.{nameof(AddBindingParameters)}");
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            Console.WriteLine($"{nameof(ServiceBehavior)}.{nameof(ApplyDispatchBehavior)}");
            foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
                ((ChannelDispatcher)channelDispatcherBase).ErrorHandlers.Add(new ErrorHandler());
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            Console.WriteLine($"{nameof(ServiceBehavior)}.{nameof(Validate)}");
        }
    }
    class ContractBehavior : IContractBehavior
    {
        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            Console.WriteLine($"{nameof(ContractBehavior)}.{nameof(AddBindingParameters)}");
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            Console.WriteLine($"{nameof(ContractBehavior)}.{nameof(ApplyClientBehavior)}");
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            Console.WriteLine($"{nameof(ContractBehavior)}.{nameof(ApplyDispatchBehavior)}");
            //dispatchRuntime.MessageInspectors.Add(new MessageHandler());
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
            Console.WriteLine($"{nameof(ContractBehavior)}.{nameof(Validate)}");
        }
    }
    class EndpointBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            Console.WriteLine($"{nameof(ContractBehavior)}.{nameof(AddBindingParameters)}");
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            Console.WriteLine($"{nameof(ContractBehavior)}.{nameof(ApplyClientBehavior)}");
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            Console.WriteLine($"{nameof(ContractBehavior)}.{nameof(ApplyDispatchBehavior)}");
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new MessageHandler());
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            Console.WriteLine($"{nameof(ContractBehavior)}.{nameof(Validate)}");
        }
    }
    class OperationBehavior : IOperationBehavior
    {
        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
            Console.WriteLine($"{nameof(ContractBehavior)}.{nameof(AddBindingParameters)}");
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            Console.WriteLine($"{nameof(ContractBehavior)}.{nameof(ApplyClientBehavior)}");
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            Console.WriteLine($"{nameof(ContractBehavior)}.{nameof(ApplyDispatchBehavior)}");
        }

        public void Validate(OperationDescription operationDescription)
        {
            Console.WriteLine($"{nameof(ContractBehavior)}.{nameof(Validate)}");
        }
    }
}
