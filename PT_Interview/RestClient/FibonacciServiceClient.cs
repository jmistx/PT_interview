using System;
using RestSharp;

namespace RestClient
{
    internal class FibonacciServiceClient : IFibonacciServiceClient
    {
        public void RequestNumber(int number)
        {
            var client = new RestSharp.RestClient("http://localhost:50990");
            var request = new RestRequest("api/Fibonacci", Method.POST);
            request.AddParameter("number", number);

            var response = client.Execute(request);
            var content = response.Content;

            Console.WriteLine("Content from service: {0}", content);
        }
    }
}