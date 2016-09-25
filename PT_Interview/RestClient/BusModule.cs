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
                    var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ReceiveEndpoint(host, "my_queue", endpoint =>
                    {
                        endpoint.Handler<CalculateNextFibonacciNumber>(async context1 =>
                        {
                            await Console.Out.WriteLineAsync($"Received: {context1.Message.Number}");
                            Program.RequestNumber(context1.Message.Number + 1);
                        });
                    });
                });
                return busControl;
            }).SingleInstance()
            .As<IBusControl>()
            .As<IBus>();
        }
    }
}