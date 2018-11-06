using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WCFConsoleRest
{
    [ServiceContract]
    public interface ICalculator
    {
        [WebGet(ResponseFormat = WebMessageFormat.Json
            , UriTemplate = "Add?n1={n1}&n2={n2}")]
        double Add(double n1, double n2);

        [WebGet(ResponseFormat = WebMessageFormat.Json
            , UriTemplate = "Subtract?n1={n1}&n2={n2}")]
        double Subtract(double n1, double n2);

        [WebGet(ResponseFormat = WebMessageFormat.Json
            , UriTemplate = "Multiply?n1={n1}&n2={n2}")]
        double Multiply(double n1, double n2);

        [WebGet(ResponseFormat = WebMessageFormat.Json
            , UriTemplate = "Divide?n1={n1}&n2={n2}")]
        double Divide(double n1, double n2);

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        string CountStatic();

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        string Count();

        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare
            , Method = "POST"
            , RequestFormat = WebMessageFormat.Json
            , ResponseFormat = WebMessageFormat.Json
            , UriTemplate = "Post")]
        string Post(string body);

        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare
            , Method = "POST"
            , RequestFormat = WebMessageFormat.Json
            , ResponseFormat = WebMessageFormat.Json
            , UriTemplate = "PostComplex")]
        Complex PostComplex(Complex body);
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
        static int staticCount;
        int count;

        public Calculator() { }

        public double Add(double n1, double n2) => n1 + n2;

        public double Divide(double n1, double n2) => n1 / n2;

        public double Multiply(double n1, double n2) => n1 * n2;

        public double Subtract(double n1, double n2) => n1 - n2;

        public string CountStatic() => $"{++staticCount},{++Static.Count}";

        public string Count() => $"{++count}";

        public string Post(string body) => body;

        public Complex PostComplex(Complex body) => body;

        static void Main(string[] args)
        {
            // Step 1 Create a URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:8000/");

            // Step 2 Create a ServiceHost instance
            using (WebServiceHost selfHost = new WebServiceHost(typeof(Calculator), baseAddress))
            {
                try
                {
                    // Step 3 Add a service endpoint.
                    selfHost.AddServiceEndpoint(typeof(ICalculator), new WebHttpBinding(), "AdditionalPath");
                    //for example http://localhost:8000/AdditionalPath/PostComplex

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
