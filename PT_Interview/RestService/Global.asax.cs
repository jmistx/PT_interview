using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using CommonContract;
using MassTransit;

namespace RestService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        static IBusControl _busControl;
        public static IBus BusControl
        {
            get { return _busControl; }
        }
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            _busControl = ConfigureBus();
            _busControl.Start();
        }
        protected void Application_End()
        {
            _busControl.Stop(); ;
        }

        IBusControl ConfigureBus()
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

            });

        }
    }
}
