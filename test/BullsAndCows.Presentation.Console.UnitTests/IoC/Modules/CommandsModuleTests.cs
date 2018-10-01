using BullsAndCows.Business.Commands.Contract;
using BullsAndCows.Presentation.Console.IoC.Modules;
using Xunit;

namespace BullsAndCows.Presentation.Console.UnitTests.IoC.Modules
{
    public class CommandsModuleTests : ModuleBaseTests
    {
        private readonly CommandsModule _instance;

        public CommandsModuleTests()
        {
            _instance = new CommandsModule();
        }

        [Fact]
        public void Configure_IRegisterSecretNumber_IsRegistered()
        {
            _instance.Configure(ComponentRegistry);

            AssertServiceExistence<IRegisterSecretNumber<int>>();
        }

        [Fact]
        public void Configure_IEvaluateSupposedDigit_IsRegistered()
        {
            _instance.Configure(ComponentRegistry);

            AssertServiceExistence<IEvaluateSupposedDigit<int>>();
        }

        [Fact]
        public void Configure_IEvaluateSupposedNumber_IsRegistered()
        {
            _instance.Configure(ComponentRegistry);

            AssertServiceExistence<IEvaluateSupposedNumber<int>>();
        }
    }
}