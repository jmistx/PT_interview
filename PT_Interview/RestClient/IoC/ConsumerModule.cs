using Autofac;

namespace RestClient.IoC
{
    public class ConsumerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FibonacciConsumer>();
        }
    }
}