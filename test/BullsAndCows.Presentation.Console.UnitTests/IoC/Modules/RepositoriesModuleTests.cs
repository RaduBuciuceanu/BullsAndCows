using BullsAndCows.Business.Repositories;
using BullsAndCows.Presentation.Console.IoC.Modules;
using Xunit;

namespace BullsAndCows.Presentation.Console.UnitTests.IoC.Modules
{
    public class RepositoriesModuleTests : ModuleBaseTests
    {
        private readonly RepositoriesModule _instance;

        public RepositoriesModuleTests()
        {
            _instance = new RepositoriesModule();
        }

        [Fact]
        public void Configure_ISecretNumberRepository_IsRegistered()
        {
            _instance.Configure(ComponentRegistry);

            AssertServiceExistence<ISecretNumberRepository>();
        }
    }
}