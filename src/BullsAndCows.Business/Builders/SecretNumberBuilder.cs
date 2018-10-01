using System.Collections.Generic;
using System.Linq;
using BullsAndCows.Business.Builders.Contract;
using BullsAndCows.Business.Models;
using BullsAndCows.Business.Models.Contract.Secret;

namespace BullsAndCows.Business.Builders
{
    public class SecretNumberBuilder<TValue> : ISecretNumberBuilder<TValue>
    {
        private readonly ICollection<ISecretDigit<TValue>> _digits;

        public SecretNumberBuilder()
        {
            _digits = new List<ISecretDigit<TValue>>();
        }

        public ISecretNumberBuilder<TValue> WithInteger(int integer)
        {
            IEnumerable<int> digits = integer.ToString().Select(instance => int.Parse(instance.ToString())).ToList();

            for (int index = 0; index < digits.Count(); index++)
            {
                WithDigit(index, digits.ElementAt(index));
            }

            return this;
        }

        public ISecretNumber<TValue> Build()
        {
            return new SecretNumber<TValue>(_digits);
        }

        private void WithDigit(int index, object digit)
        {
            var secretDigit = new SecretDigit<TValue>(index, (TValue) digit);
            _digits.Add(secretDigit);
        }
    }
}