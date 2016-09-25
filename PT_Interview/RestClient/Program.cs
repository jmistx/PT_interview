﻿using System;
using Autofac;
using CommonContract;
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
            var container = builder.Build();

            var bus = container.Resolve<IBusControl>();

            using (bus.Start())
            {
                Console.WriteLine("Waiting for message...");
                Console.ReadKey();
            }
        }
    }

    public class BusModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ReceiveEndpoint(host, "my_queue", endpoint =>
                    {
                        endpoint.Handler<CalculateNextFibonacciNumber>(async context1 =>
                        {
                            await Console.Out.WriteLineAsync($"Received: {context1.Message.Number}");
                            Program.RequestNumber(context1.Message.Number + 1);
                        });
                    });
                });
                return busControl;
            }).SingleInstance()
            .As<IBusControl>()
            .As<IBus>();
        }
    }
}