using Autofac;
using BullsAndCows.Business.Commands;
using BullsAndCows.Business.Commands.Contract;
using BullsAndCows.Business.Commands.Contract.Validations;
using BullsAndCows.Business.Commands.Validations;

namespace BullsAndCows.Presentation.Console.IoC.Modules
{
    public class CommandsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<DistinctDigitsValidation<int>>()
                .As<IDistinctDigitsValidation<int>>();

            builder
                .RegisterType<RegisterSecretNumber<int>>()
                .As<IRegisterSecretNumber<int>>();

            builder
                .RegisterType<EvaluateSupposedDigit<int>>()
                .As<IEvaluateSupposedDigit<int>>();

            builder
                .RegisterType<EvaluateSupposedNumber<int>>()
                .As<IEvaluateSupposedNumber<int>>();
        }
    }
}