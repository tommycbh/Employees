using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Http.Controllers;
using Employees.Web.Plumbing;
using Employees.EntityFramework;
using Employees.Core.Repositories;
using Employees.EntityFramework.Repositories;
using Employees.Core.Services;

namespace Employees.Web.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.
                    FromThisAssembly().
                    BasedOn<IController>().
                    If(c => c.Name.EndsWith("Controller")).
                    LifestyleTransient());

            container.Register(
                Classes.
                    FromThisAssembly().
                    BasedOn<IHttpController>().
                    If(c => c.Name.EndsWith("Controller")).LifestyleTransient());

            container.Register(Component.For<EmployeesDbContext>().LifeStyle.PerThread);

            container.Register(Component.For<IEmploeesRepository>().ImplementedBy<EmploeesRepository>().LifeStyle.Transient);
            container.Register(Component.For<IRegionsRepository>().ImplementedBy<RegionsRepository>().LifeStyle.Transient);

            container.Register(Component.For<IEmployeesService>().ImplementedBy<EmployeesService>().LifeStyle.Transient);
            container.Register(Component.For<IRegionService>().ImplementedBy<RegionService>().LifeStyle.Transient);

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
        }
    }
}