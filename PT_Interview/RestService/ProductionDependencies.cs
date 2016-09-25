using Autofac;
using Domain;
using log4net;

namespace RestService
{
    public class ProductionDependencies : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<BusModule>();
            builder.RegisterType<FibonacciCalculator>().As<IFibonacciCalculator>();
            builder.Register(_ => LogManager.GetLogger("")).As<ILog>();
        }
    }
}