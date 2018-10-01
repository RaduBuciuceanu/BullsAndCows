using BullsAndCows.Business.Models.Contract.Supposed;

namespace BullsAndCows.Business.Models
{
    public class SupposedDigit<TValue> : ISupposedDigit<TValue>
    {
        public int Index { get; }

        public TValue Value { get; }

        public SupposedDigit(int index, TValue value)
        {
            Index = index;
            Value = value;
        }
    }
}