using System.Collections.Generic;
using BullsAndCows.Business.Models.Contract.Secret;

namespace BullsAndCows.Business.Models
{
    public class SecretNumber<TValue> : ISecretNumber<TValue>
    {
        public IEnumerable<ISecretDigit<TValue>> Digits { get; }

        public SecretNumber(IEnumerable<ISecretDigit<TValue>> digits)
        {
            Digits = digits;
        }
    }
}