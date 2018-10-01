using System;
using System.Collections.Generic;
using System.Linq;
using BullsAndCows.Business.Commands.Contract;
using BullsAndCows.Business.Commands.Contract.Validations;
using BullsAndCows.Business.Models.Contract.Supposed;

namespace BullsAndCows.Business.Commands.Validations
{
    public class DistinctDigitsValidation<TValue> : IDistinctDigitsValidation<TValue>
    {
        public Unit Execute(ISupposedNumber<TValue> parameter)
        {
            IEnumerable<TValue> digits = parameter.Digits.Select(instance => instance.Value).ToList();
            IEnumerable<TValue> distinctDigits = digits.Distinct();

            if (digits.Count() != distinctDigits.Count())
            {
                throw new Exception("All the digits from the supposed number should be distinct.");
            }

            return Unit.Default;
        }
    }
}