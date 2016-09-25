using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using MassTransit;

namespace RestService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        static IBusControl _busControl;
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var container = ConfigureIocContainer();

            _busControl = container.Resolve<IBusControl>();
            _busControl.Start();
        }

        private static IContainer ConfigureIocContainer()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule<ProductionDependencies>();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return container;
        }

        protected void Application_End()
        {
            _busControl.Stop();
        }
        
    }
}
