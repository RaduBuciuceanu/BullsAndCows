using BullsAndCows.Presentation.Console.Commands.Contract;
using BullsAndCows.Presentation.Console.IoC.Modules;
using Xunit;

namespace BullsAndCows.Presentation.Console.UnitTests.IoC.Modules
{
    public class ApplicationModuleTests : ModuleBaseTests
    {
        private readonly ApplicationModule _instance;

        public ApplicationModuleTests()
        {
            _instance = new ApplicationModule();
        }

        [Fact]
        public void Configure_IDefineSecretNumber_IsRegistered()
        {
            _instance.Configure(ComponentRegistry);

            AssertServiceExistence<IDefineSecretNumber>();
        }

        [Fact]
        public void Configure_ISupposeSecretNumber_IsRegistered()
        {
            _instance.Configure(ComponentRegistry);

            AssertServiceExistence<ISupposeSecretNumber>();
        }

        [Fact]
        public void Configure_Application_IsRegistered()
        {
            _instance.Configure(ComponentRegistry);

            AssertServiceExistence<Application>();
        }
    }
}