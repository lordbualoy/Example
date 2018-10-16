using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Runtime.Serialization;

namespace WCFConsole
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract]
        double Subtract(double n1, double n2);
        [OperationContract]
        double Multiply(double n1, double n2);
        [OperationContract]
        double Divide(double n1, double n2);
        [OperationContract]
        string Count();
        [OperationContract]
        Complex Complex(Complex complex);
    }

    [DataContract]
    public class Complex
    {
        [DataMember]
        public string Data { get; set; }
    }

    public static class Static
    {
        public static int Count { get; set; }
    }

    public class Calculator : ICalculator
    {
        static int count;

        public double Add(double n1, double n2) => n1 + n2;

        public double Divide(double n1, double n2) => n1 / n2;

        public double Multiply(double n1, double n2) => n1 * n2;

        public double Subtract(double n1, double n2) => n1 - n2;

        public string Count() => $"{++count},{++Static.Count}";

        public Complex Complex(Complex complex) => complex;

        static void Main(string[] args)
        {
            // Step 1 Create a URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:8000/");

            // Step 2 Create a ServiceHost instance
            using (ServiceHost selfHost = new ServiceHost(typeof(Calculator), baseAddress))
            {
                try
                {
                    // Step 3 Add a service endpoint.
                    selfHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "Calculator");

                    // Step 4 Enable metadata exchange.
                    selfHost.Description.Behaviors.Add(new ServiceMetadataBehavior
                    {
                        HttpGetEnabled = true,
                    });

                    // Step 5 Start the service.
                    selfHost.Open();
                    Console.WriteLine("The service is ready.");
                    Console.WriteLine("Press <ENTER> to terminate service.");
                    Console.WriteLine();
                    Console.ReadLine();

                    // Close the ServiceHostBase to shutdown the service.
                    selfHost.Close();
                }
                catch (CommunicationException ce)
                {
                    Console.WriteLine("An exception occurred: {0}", ce.Message);
                    selfHost.Abort();
                }
            }
        }
    }
}
