using System.Collections.Generic;

namespace BullsAndCows.Business.Models.Contract.Supposed
{
    public interface ISupposedNumber<out TValue>
    {
        IEnumerable<ISupposedDigit<TValue>> Digits { get; }
    }
}