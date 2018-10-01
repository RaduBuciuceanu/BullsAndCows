using Autofac;
using BullsAndCows.Business.Repositories;
using BullsAndCows.Data.Repositories;

namespace BullsAndCows.Presentation.Console.IoC.Modules
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<SecretNumberRepository>()
                .As<ISecretNumberRepository>()
                .SingleInstance();
        }
    }
}