using Autofac;
using Domain;
using log4net;

namespace RestClient.IoC
{
    internal class ProductionDependencies : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<BusModule>();
            builder.RegisterModule<ConsumerModule>();
            builder.RegisterType<FibonacciServiceClient>().As<IFibonacciServiceClient>();
            builder.RegisterType<FibonacciCalculator>().As<IFibonacciCalculator>();
            builder.Register(_ => LogManager.GetLogger("")).As<ILog>();
        }
    }
}