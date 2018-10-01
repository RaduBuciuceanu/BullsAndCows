using Autofac;
using BullsAndCows.Business.Commands.Contract;
using BullsAndCows.Presentation.Console.Commands.Contract;

namespace BullsAndCows.Presentation.Console
{
    public class Application
    {
        private readonly ILifetimeScope _scope;

        private IDefineSecretNumber DefineSecretNumber => _scope.Resolve<IDefineSecretNumber>();

        private ISupposeSecretNumber SupposeSecretNumber => _scope.Resolve<ISupposeSecretNumber>();

        public Application(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public void Execute()
        {
            DefineSecretNumber.Execute(Unit.Default);
            SupposeSecretNumber.Execute(Unit.Default);

            System.Console.WriteLine("Congrats, you won the game.");
        }
    }
}