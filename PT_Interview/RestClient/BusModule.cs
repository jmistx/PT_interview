using System;
using Autofac;
using CommonContract;
using MassTransit;

namespace RestClient
{
    public class BusModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ReceiveEndpoint("my_queue", ec =>
                    {
                        ec.LoadFrom(context);
                    });
                });
                return busControl;
            }).SingleInstance()
            .As<IBusControl>()
            .As<IBus>();
        }
    }
}