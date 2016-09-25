using System;
using Autofac;
using MassTransit;

namespace RestClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<BusModule>();
            builder.RegisterModule<ConsumerModule>();
            builder.RegisterType<FibonacciServiceClient>().As<IFibonacciServiceClient>();
            var container = builder.Build();

            BeginConversation(container);
        }

        private static void BeginConversation(IContainer container)
        {
            var bus = container.Resolve<IBusControl>();
            var fibonacciServiceClient = container.Resolve<IFibonacciServiceClient>();
            fibonacciServiceClient.RequestNumber(5);

            using (bus.Start())
            {
                Console.WriteLine("Press any key for exit.");
                Console.WriteLine("Waiting for messages...");
                Console.ReadKey();
            }
        }
    }
}