using System.Collections.Generic;
using BullsAndCows.Business.Models.Contract.Supposed;

namespace BullsAndCows.Business.Models
{
    public class SupposedNumber<TValue> : ISupposedNumber<TValue>
    {
        public IEnumerable<ISupposedDigit<TValue>> Digits { get; }

        public SupposedNumber(IEnumerable<ISupposedDigit<TValue>> digits)
        {
            Digits = digits;
        }
    }
}