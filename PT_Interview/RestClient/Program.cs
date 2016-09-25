using System;
using Autofac;
using MassTransit;
using RestClient.IoC;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace RestClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ProductionDependencies>();
            var container = builder.Build();

            BeginConversation(container, args);
        }

        private static UInt64 ParseToInitialNumber(string[] args)
        {
            return UInt64.Parse(args[0]);
        }

        private static void BeginConversation(IContainer container, string[] args)
        {
            var bus = container.Resolve<IBusControl>();
            var fibonacciServiceClient = container.Resolve<IFibonacciServiceClient>();
            var initialNumber = ParseToInitialNumber(args);

            fibonacciServiceClient.RequestNextNumber(initialNumber);

            using (bus.Start())
            {
                Console.WriteLine("Press any key for exit.");
                Console.WriteLine("Waiting for messages...");
                Console.ReadKey();
            }
        }
    }
}