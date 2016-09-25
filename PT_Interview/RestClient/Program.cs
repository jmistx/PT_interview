using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonContract;
using MassTransit;
using RestSharp;

namespace RestClient
{
    class Program
    {
        static void RequestNumber(int number)
        {
            var client = new RestSharp.RestClient("http://localhost:50990");
            var request = new RestRequest("api/Fibonacci", Method.POST);
            request.AddParameter("number", number);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            Console.WriteLine("Content from service: {0}", content);
        }
        static void Main(string[] args)
        {
            
            RequestNumber(5);
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint(host, "my_queue", endpoint =>
                {
                    endpoint.Handler<CalculateNextFibonacciNumber>(async context =>
                    {
                        await Console.Out.WriteLineAsync($"Received: {context.Message.Number}");
                        RequestNumber(context.Message.Number + 1);
                    });
                });
            });

            using (bus.Start())
            {
                Console.WriteLine("Waiting for message...");
                Console.ReadKey();
            }
        }
    }
}
