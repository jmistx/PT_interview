using System;
using Autofac;
using MassTransit;
using RestSharp;

namespace RestClient
{
    internal class Program
    {
        public static void RequestNumber(int number)
        {
            var client = new RestSharp.RestClient("http://localhost:50990");
            var request = new RestRequest("api/Fibonacci", Method.POST);
            request.AddParameter("number", number);

            var response = client.Execute(request);
            var content = response.Content;

            Console.WriteLine("Content from service: {0}", content);
        }

        private static void Main(string[] args)
        {
            RequestNumber(5);
            var builder = new ContainerBuilder();
            builder.RegisterModule<BusModule>();
            builder.RegisterModule<ConsumerModule>();
            var container = builder.Build();

            var bus = container.Resolve<IBusControl>();

            using (bus.Start())
            {
                Console.WriteLine("Waiting for message...");
                Console.ReadKey();
            }
        }
    }
}