using BullsAndCows.Business.Builders.Contract;
using BullsAndCows.Presentation.Console.IoC.Modules;
using Xunit;

namespace BullsAndCows.Presentation.Console.UnitTests.IoC.Modules
{
    public class BuildersModuleTests : ModuleBaseTests
    {
        private readonly BuildersModule _instance;

        public BuildersModuleTests()
        {
            _instance = new BuildersModule();
        }

        [Fact]
        public void Configure_ISecretNumberBuilder_IsRegistered()
        {
            _instance.Configure(ComponentRegistry);

            AssertServiceExistence<ISecretNumberBuilder<int>>();
        }

        [Fact]
        public void Configure_ISupposedNumberBuilder_IsRegistered()
        {
            _instance.Configure(ComponentRegistry);

            AssertServiceExistence<ISupposedNumberBuilder<int>>();
        }
    }
}