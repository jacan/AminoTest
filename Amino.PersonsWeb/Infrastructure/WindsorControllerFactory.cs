﻿using System;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel;
using Castle.Core.Logging;

namespace Amino.PersonsWeb.Infrastructure
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public WindsorControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                
                throw new HttpException(404, string.Format("The controller for path {0} could not be found!!", requestContext.HttpContext.Request.Path));
            }

            return (IController)_kernel.Resolve(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            _kernel.ReleaseComponent(controller);
        }
    }
}