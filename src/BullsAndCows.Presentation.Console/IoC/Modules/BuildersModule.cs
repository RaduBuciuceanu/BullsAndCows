using Autofac;
using BullsAndCows.Business.Builders;
using BullsAndCows.Business.Builders.Contract;

namespace BullsAndCows.Presentation.Console.IoC.Modules
{
    public class BuildersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<SecretNumberBuilder<int>>()
                .As<ISecretNumberBuilder<int>>()
                .InstancePerDependency();

            builder
                .RegisterType<SupposedNumberBuilder<int>>()
                .As<ISupposedNumberBuilder<int>>()
                .InstancePerDependency();
        }
    }
}