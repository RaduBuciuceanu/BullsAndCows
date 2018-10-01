using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using BullsAndCows.Business.Builders.Contract;
using BullsAndCows.Business.Commands.Contract;
using BullsAndCows.Business.Repositories;
using BullsAndCows.Presentation.Console.Commands.Contract;
using BullsAndCows.Presentation.Console.IoC;
using Shouldly;
using Xunit;

namespace BullsAndCows.Presentation.Console.UnitTests.IoC
{
    public class LifetimeScopeBuilderTests
    {
        private readonly LifetimeScopeBuilder _instance;

        public LifetimeScopeBuilderTests()
        {
            _instance = new LifetimeScopeBuilder();
        }

        [Fact]
        public void WithModules_Returns_Itself()
        {
            LifetimeScopeBuilder actual = _instance.WithModules();

            actual.ShouldBe(_instance);
        }

        [Fact]
        public void Build_DoesNot_ReturnNull()
        {
            ILifetimeScope actual = _instance.Build();

            actual.ShouldNotBeNull();
        }

        [Fact]
        public void WithModules_IDefineSecretNumber_IsRegistered()
        {
            ILifetimeScope actual = _instance.WithModules().Build();

            AssertServiceExistence<IDefineSecretNumber>(actual);
        }

        [Fact]
        public void WithModules_ISupposeSecretNumber_IsRegistered()
        {
            ILifetimeScope actual = _instance.WithModules().Build();

            AssertServiceExistence<ISupposeSecretNumber>(actual);
        }

        [Fact]
        public void WithModules_Application_IsRegistered()
        {
            ILifetimeScope actual = _instance.WithModules().Build();

            AssertServiceExistence<Application>(actual);
        }

        [Fact]
        public void WithModules_ISecretNumberBuilder_IsRegistered()
        {
            ILifetimeScope actual = _instance.WithModules().Build();

            AssertServiceExistence<ISecretNumberBuilder<int>>(actual);
        }

        [Fact]
        public void WithModules_ISupposedNumberBuilder_IsRegistered()
        {
            ILifetimeScope actual = _instance.WithModules().Build();

            AssertServiceExistence<ISupposedNumberBuilder<int>>(actual);
        }

        [Fact]
        public void WithModules_IRegisterSecretNumber_IsRegistered()
        {
            ILifetimeScope actual = _instance.WithModules().Build();

            AssertServiceExistence<IRegisterSecretNumber<int>>(actual);
        }

        [Fact]
        public void WithModules_IEvaluateSupposedDigit_IsRegistered()
        {
            ILifetimeScope actual = _instance.WithModules().Build();

            AssertServiceExistence<IEvaluateSupposedDigit<int>>(actual);
        }

        [Fact]
        public void WithModules_IEvaluateSupposedNumber_IsRegistered()
        {
            ILifetimeScope actual = _instance.WithModules().Build();

            AssertServiceExistence<IEvaluateSupposedNumber<int>>(actual);
        }

        [Fact]
        public void WithModules_ISecretNumberRepository_IsRegistered()
        {
            ILifetimeScope actual = _instance.WithModules().Build();

            AssertServiceExistence<ISecretNumberRepository>(actual);
        }

        private void AssertServiceExistence<TService>(ILifetimeScope scope)
        {
            IEnumerable<IServiceWithType> registeredServices = GetRegisteredServices(scope);
            registeredServices.ShouldContain(instance => instance.ServiceType == typeof(TService));
        }

        private IEnumerable<IServiceWithType> GetRegisteredServices(ILifetimeScope scope)
        {
            return scope
                .ComponentRegistry
                .Registrations
                .SelectMany(instance => instance.Services)
                .OfType<IServiceWithType>();
        }
    }
}