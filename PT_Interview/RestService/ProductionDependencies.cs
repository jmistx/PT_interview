using Autofac;

namespace RestService
{
    public class ProductionDependencies : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<BusModule>();
        }
    }
}