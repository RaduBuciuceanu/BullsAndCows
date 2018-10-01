using System.Collections.Generic;

namespace BullsAndCows.Business.Models.Contract.Secret
{
    public interface ISecretNumber<out TValue>
    {
        IEnumerable<ISecretDigit<TValue>> Digits { get; }
    }
}