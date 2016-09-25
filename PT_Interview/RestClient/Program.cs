using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace RestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestSharp.RestClient("http://localhost:50990");
            var request = new RestRequest("api/Fibonacci", Method.POST);
            request.AddParameter("number", 5);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            Console.WriteLine("Content from service: {0}", content);
        }
    }
}
