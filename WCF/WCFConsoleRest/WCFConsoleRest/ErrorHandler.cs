using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace WCFConsoleRest
{
    class ErrorHandler : IErrorHandler
    {
        /// <summary>
        /// The method that's get invoked if any unhandled exception raised in service
        /// Here you can do what ever logic you would like to. 
        /// For example logging the exception details
        /// Here the return value indicates that the exception was handled or not
        /// Return true to stop exception propagation and system considers 
        /// that the exception was handled properly
        /// else return false to abort the session
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool HandleError(Exception error)
        {
            Console.WriteLine(error.Message);
            return true;
        }

        /// <summary>
        /// If you want to communicate the exception details to the service client 
        /// as proper fault message
        /// here is the place to do it
        /// If we want to suppress the communication about the exception, 
        /// set fault to null
        /// </summary>
        /// <param name="error"></param>
        /// <param name="version"></param>
        /// <param name="fault"></param>
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            Error e = new Error { Message = $"Exception caught at Service Application GlobalErrorHandler Method: {error.TargetSite.Name} Message: {error.Message}" };
            fault = Message.CreateMessage(version, "", e, new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(Error)));
            fault.Properties.Add(WebBodyFormatMessageProperty.Name, new WebBodyFormatMessageProperty(WebContentFormat.Json));

            var httpResponseMessageproperty = new HttpResponseMessageProperty
            {
                StatusCode = System.Net.HttpStatusCode.PaymentRequired,
            };
            httpResponseMessageproperty.Headers[System.Net.HttpResponseHeader.ContentType] = "application/json";
            fault.Properties.Add(HttpResponseMessageProperty.Name, httpResponseMessageproperty);
        }
    }
}
