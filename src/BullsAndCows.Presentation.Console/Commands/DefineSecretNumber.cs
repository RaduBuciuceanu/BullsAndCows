using System;
using Autofac;
using BullsAndCows.Business.Builders.Contract;
using BullsAndCows.Business.Commands.Contract;
using BullsAndCows.Business.Models.Contract.Secret;
using BullsAndCows.Presentation.Console.Commands.Contract;

namespace BullsAndCows.Presentation.Console.Commands
{
    public class DefineSecretNumber : IDefineSecretNumber
    {
        private readonly IRegisterSecretNumber<int> _registerSecretNumber;
        private readonly ISecretNumberBuilder<int> _secretNumberBuilder;

        public DefineSecretNumber(ILifetimeScope scope)
        {
            _registerSecretNumber = scope.Resolve<IRegisterSecretNumber<int>>();
            _secretNumberBuilder = scope.Resolve<ISecretNumberBuilder<int>>();
        }

        public Unit Execute(Unit parameter)
        {
            int input = ReadSecretNumber();
            ISecretNumber<int> secretNumber = _secretNumberBuilder.WithInteger(input).Build();
            _registerSecretNumber.Execute(secretNumber);

            return Unit.Default;
        }

        private static int ReadSecretNumber()
        {
            try
            {
                System.Console.Write("Secret number: ");
                return int.Parse(System.Console.ReadLine());
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception.Message);
                return ReadSecretNumber();
            }
        }
    }
}