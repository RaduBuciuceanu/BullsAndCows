using BullsAndCows.Business.Models.Contract.Secret;

namespace BullsAndCows.Business.Models
{
    public class SecretDigit<TValue> : ISecretDigit<TValue>
    {
        public int Index { get; }

        public TValue Value { get; }

        public SecretDigit(int index, TValue value)
        {
            Index = index;
            Value = value;
        }
    }
}