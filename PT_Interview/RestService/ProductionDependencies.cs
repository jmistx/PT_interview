using Autofac;
using Domain;

namespace RestService
{
    public class ProductionDependencies : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<BusModule>();
            builder.RegisterType<FibonacciCalculator>().As<IFibonacciCalculator>();
        }
    }
}