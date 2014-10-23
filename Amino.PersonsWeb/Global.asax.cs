using System;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Amino.Domain.Factories;
using Amino.PersonsWeb.ApplicationServices;
using Amino.PersonsWeb.Infrastructure;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Amino.PersonsRepository;
using System.Threading;

namespace Amino.PersonsWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _windsorContainer;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            WireupContainer();
        }

        private static void WireupContainer()
        {
            _windsorContainer = new WindsorContainer()
                .Install(FromAssembly.This())
                .Register(
                    Classes.FromThisAssembly()
                        .InSameNamespaceAs<IPersonsApplicationService>()
                        .WithServiceAllInterfaces()
                        .LifestyleTransient())
                .Register(
                    Classes.FromAssemblyContaining<IPersonFactory>()
                        .InSameNamespaceAs<IPersonFactory>()
                        .WithServiceAllInterfaces()
                        .LifestyleTransient())
                .Register(Types
                    .FromAssemblyContaining<PersonRepository>()
                    .Where(t => t.Name.EndsWith("Repository", StringComparison.Ordinal))
                    .WithService
                    .FirstInterface()
                    .Configure(reg => reg.LifestyleTransient()));
                
            var controllerFactory = new WindsorControllerFactory(_windsorContainer.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        protected void Application_End()
        {
            _windsorContainer.Dispose();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var cultureName = HttpContext.Current.Request.UserLanguages[0];
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
        }
    }
}
