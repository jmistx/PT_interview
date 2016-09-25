using Autofac;

namespace RestClient
{
    public class ConsumerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FibonacciConsumer>();
        }
    }
}