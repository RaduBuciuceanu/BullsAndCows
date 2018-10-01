using System.Collections.Generic;
using System.Linq;
using BullsAndCows.Business.Builders.Contract;
using BullsAndCows.Business.Models;
using BullsAndCows.Business.Models.Contract.Supposed;

namespace BullsAndCows.Business.Builders
{
    public class SupposedNumberBuilder<TValue> : ISupposedNumberBuilder<TValue>
    {
        private readonly ICollection<ISupposedDigit<TValue>> _digits;

        public SupposedNumberBuilder()
        {
            _digits = new List<ISupposedDigit<TValue>>();
        }

        public ISupposedNumberBuilder<TValue> WithInteger(int integer)
        {
            IEnumerable<int> digits = integer.ToString().Select(instance => int.Parse(instance.ToString())).ToList();

            for (int index = 0; index < digits.Count(); index++)
            {
                WithDigit(index, digits.ElementAt(index));
            }

            return this;
        }

        public ISupposedNumber<TValue> Build()
        {
            return new SupposedNumber<TValue>(_digits);
        }

        private void WithDigit(int index, object digit)
        {
            var secretDigit = new SupposedDigit<TValue>(index, (TValue) digit);
            _digits.Add(secretDigit);
        }
    }
}