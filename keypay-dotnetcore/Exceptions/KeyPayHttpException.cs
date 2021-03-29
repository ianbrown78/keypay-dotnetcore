using System;
using System.Net;
using RestSharp;

namespace KeyPay.Exceptions
{
    public class KeyPayHttpException : Exception
    {
        private HttpStatusCode StatusCode { get; }
        private string StatusMessage { get; }
        private Method RequestMethod { get; }
        private string RequestResource { get; }
        private string ResponseContent { get; }

        public KeyPayHttpException(HttpStatusCode statusCode, string message, Method requestMethod, string requestResource, string responseContent) : base($"Error during {requestMethod} to {requestResource}. Received status code {(int)statusCode} : {message}. See ResponseContent property for details")
        {
            StatusCode = statusCode;
            StatusMessage = message;
            RequestMethod = requestMethod;
            RequestResource = requestResource;
            ResponseContent = responseContent;
        }
    }
}