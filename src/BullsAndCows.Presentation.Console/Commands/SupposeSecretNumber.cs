using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using BullsAndCows.Business.Builders.Contract;
using BullsAndCows.Business.Commands.Contract;
using BullsAndCows.Business.Models.Contract;
using BullsAndCows.Business.Models.Contract.Supposed;
using BullsAndCows.Business.Repositories;
using BullsAndCows.Presentation.Console.Commands.Contract;

namespace BullsAndCows.Presentation.Console.Commands
{
    public class SupposeSecretNumber : ISupposeSecretNumber
    {
        private readonly ILifetimeScope _scope;

        private int _bullsCount;

        private ISupposedNumberBuilder<int> SupposedNumberBuilder => _scope.Resolve<ISupposedNumberBuilder<int>>();

        private IEvaluateSupposedNumber<int> EvaluateSupposedNumber => _scope.Resolve<IEvaluateSupposedNumber<int>>();

        private ISecretNumberRepository SecretNumberRepository => _scope.Resolve<ISecretNumberRepository>();

        public SupposeSecretNumber(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public Unit Execute(Unit parameter)
        {
            while (IsGuessWrong())
            {
                TrySupposeOnce();
            }

            return Unit.Default;
        }

        private bool IsGuessWrong()
        {
            return _bullsCount != SecretNumberRepository.Get<int>().Digits.Count();
        }

        private void TrySupposeOnce()
        {
            try
            {
                ISupposedNumber<int> supposedNumber = ReadSupposedNumber();
                IEnumerable<IEvaluationResult> evaluationResult = Evaluate(supposedNumber).ToList();

                _bullsCount = GetBullsCount(evaluationResult);
                int cowsCount = GetCowsCount(evaluationResult);

                PrintCowsCount(cowsCount);
                PrintBullsCount(_bullsCount);
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }
        }

        private ISupposedNumber<int> ReadSupposedNumber()
        {
            System.Console.Write("Supposed number: ");

            var input = int.Parse(System.Console.ReadLine());
            return SupposedNumberBuilder.WithInteger(input).Build();
        }

        private IEnumerable<IEvaluationResult> Evaluate(ISupposedNumber<int> supposedNumber)
        {
            return EvaluateSupposedNumber.Execute(supposedNumber).ToList();
        }

        private static int GetCowsCount(IEnumerable<IEvaluationResult> evaluationResult)
        {
            return evaluationResult.Count(instance => instance is ICow<int>);
        }

        private static int GetBullsCount(IEnumerable<IEvaluationResult> evaluationResult)
        {
            return evaluationResult.Count(instance => instance is IBull<int>);
        }

        private static void PrintCowsCount(int count)
        {
            System.Console.WriteLine($"Cows: {count}");
        }

        private static void PrintBullsCount(int count)
        {
            System.Console.WriteLine($"Bulls: {count}");
        }
    }
}