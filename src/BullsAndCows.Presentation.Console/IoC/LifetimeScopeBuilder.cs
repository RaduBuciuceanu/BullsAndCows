using Autofac;
using BullsAndCows.Presentation.Console.IoC.Modules;

namespace BullsAndCows.Presentation.Console.IoC
{
    public class LifetimeScopeBuilder
    {
        private readonly ContainerBuilder _builder;

        public LifetimeScopeBuilder()
        {
            _builder = new ContainerBuilder();
        }

        public LifetimeScopeBuilder WithModules()
        {
            _builder
                .RegisterModule<RepositoriesModule>()
                .RegisterModule<CommandsModule>()
                .RegisterModule<BuildersModule>()
                .RegisterModule<ApplicationModule>();

            return this;
        }

        public ILifetimeScope Build()
        {
            return _builder.Build().BeginLifetimeScope();
        }
    }
}