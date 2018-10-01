using Autofac;
using BullsAndCows.Presentation.Console.Commands;
using BullsAndCows.Presentation.Console.Commands.Contract;

namespace BullsAndCows.Presentation.Console.IoC.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<DefineSecretNumber>()
                .As<IDefineSecretNumber>();

            builder
                .RegisterType<SupposeSecretNumber>()
                .As<ISupposeSecretNumber>();

            builder
                .RegisterType<Application>()
                .AsSelf();
        }
    }
}