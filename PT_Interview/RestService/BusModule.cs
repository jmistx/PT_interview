using System;
using Autofac;
using MassTransit;

namespace RestService
{
    public class BusModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });

            builder
                .Register(context => bus)
                .SingleInstance()
                .As<IBus>()
                .As<IBusControl>();
        }
    }
}