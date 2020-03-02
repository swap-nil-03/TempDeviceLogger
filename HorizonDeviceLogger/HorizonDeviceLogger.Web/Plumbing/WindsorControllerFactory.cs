using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace HorizonDeviceLogger.Web.Plumbing
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        readonly IWindsorContainer container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            this.container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            //if (controllerType != null && container.Kernel.HasComponent(controllerType))
            //	return (IController)container.Resolve(controllerType);

            //return base.GetControllerInstance(requestContext, controllerType);
            if (controllerType != null && container.Kernel.HasComponent(controllerType))
            {
                return (IController)container.Resolve(controllerType);
            }
            else
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }
        }

        public override void ReleaseController(IController controller)
        {
            container.Release(controller);
        }
    }
}