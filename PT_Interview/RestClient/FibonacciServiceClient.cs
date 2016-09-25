using System;
using log4net;
using RestSharp;

namespace RestClient
{
    internal class FibonacciServiceClient : IFibonacciServiceClient
    {
        private readonly ILog _log;

        public FibonacciServiceClient(ILog log)
        {
            _log = log;
        }

        public void RequestNextNumber(UInt64 number)
        {
            var client = new RestSharp.RestClient("http://localhost:50990");
            var request = new RestRequest("api/Fibonacci", Method.POST);
            request.AddParameter("number", number);

            var response = client.Execute(request);
            var content = response.Content;

            _log.Debug($"Content from service: {content}");
        }
    }
}