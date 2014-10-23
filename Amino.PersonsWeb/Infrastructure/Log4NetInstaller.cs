using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;

namespace Amino.PersonsWeb.Infrastructure
{
    public class Log4NetInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.AddFacility<LoggingFacility>(facility => facility.UseLog4Net());
        }
    }
}