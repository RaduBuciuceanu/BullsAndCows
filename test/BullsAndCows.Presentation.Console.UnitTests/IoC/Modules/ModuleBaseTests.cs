using System.Collections.Generic;
using System.Linq;
using Autofac.Core;
using Autofac.Core.Registration;
using Shouldly;

namespace BullsAndCows.Presentation.Console.UnitTests.IoC.Modules
{
    public abstract class ModuleBaseTests
    {
        protected readonly IComponentRegistry ComponentRegistry;

        protected ModuleBaseTests()
        {
            ComponentRegistry = new ComponentRegistry();
        }

        protected void AssertServiceExistence<TService>()
        {
            IEnumerable<IServiceWithType> registeredServices = GetRegisteredServices();
            registeredServices.ShouldContain(instance => instance.ServiceType == typeof(TService));
        }

        private IEnumerable<IServiceWithType> GetRegisteredServices()
        {
            return ComponentRegistry
                .Registrations
                .SelectMany(instance => instance.Services)
                .OfType<IServiceWithType>();
        }
    }
}