using System.Linq;
using BullsAndCows.Business.Commands.Contract;
using BullsAndCows.Business.Models;
using BullsAndCows.Business.Models.Contract;
using BullsAndCows.Business.Models.Contract.Secret;
using BullsAndCows.Business.Models.Contract.Supposed;
using BullsAndCows.Business.Repositories;

namespace BullsAndCows.Business.Commands
{
    public class EvaluateSupposedDigit<TValue> : IEvaluateSupposedDigit<TValue>
    {
        private readonly ISecretNumberRepository _repository;

        public EvaluateSupposedDigit(ISecretNumberRepository repository)
        {
            _repository = repository;
        }

        public IEvaluationResult Execute(ISupposedDigit<TValue> parameter)
        {
            if (IsBull(parameter))
            {
                return new Bull<TValue>(parameter.Index, parameter.Value);
            }

            if (IsCow(parameter))
            {
                return new Cow<TValue>(parameter.Index, parameter.Value);
            }

            return new EmptyEvaluationResult();
        }

        private bool IsBull(ISupposedDigit<TValue> parameter)
        {
            ISecretDigit<TValue> secretDigit = GetSecretDigit(parameter.Index);
            return secretDigit.Value.Equals(parameter.Value);
        }

        private bool IsCow(ISupposedDigit<TValue> parameter)
        {
            return GetSecretNumber().Digits.Any(digit => digit.Value.Equals(parameter.Value));
        }

        private ISecretNumber<TValue> GetSecretNumber()
        {
            return _repository.Get<TValue>();
        }

        private ISecretDigit<TValue> GetSecretDigit(int index)
        {
            return GetSecretNumber().Digits.Single(instance => instance.Index == index);
        }
    }
}