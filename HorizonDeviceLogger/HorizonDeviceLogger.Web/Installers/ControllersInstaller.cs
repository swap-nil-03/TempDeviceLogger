using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using HorizonDeviceLogger.ActionInterfaces;
using HorizonDeviceLogger.AdapterInterfaces;
using HorizonDeviceLogger.RepositoryInterfaces;

namespace HorizonDeviceLogger.Web.Installers
{
    using Plumbing;
    using System.Web.Http;
    using System.Web.Http.Controllers;

    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(
            //    Classes.
            //        FromThisAssembly().
            //        BasedOn<IController>().
            //        If(c => c.Name.EndsWith("Controller")).
            //        LifestyleTransient());

            //ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
            container.Register(Classes.FromThisAssembly().BasedOn<IController>().If(c => c.Name.EndsWith("Controller")).LifestyleTransient());
            //container.Register(Classes.FromThisAssembly().BasedOn<IHttpController>().If(c => c.Name.EndsWith("ApiController")).LifestyleTransient());

            container.Register(
                Classes
                    .FromThisAssembly()
                    .BasedOn<ApiController>()
                    .LifestyleScoped()
                );

            container.Register(Classes.FromAssemblyNamed("HorizonDeviceLogger.Action").BasedOn<IMasterAction>().WithService.DefaultInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyNamed("HorizonDeviceLogger.Adapter").BasedOn<IMasterAdapter>().WithService.DefaultInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyNamed("HorizonDeviceLogger.Repository").BasedOn<IMasterRepository>().WithService.DefaultInterfaces().LifestyleTransient());
        }
    }
}