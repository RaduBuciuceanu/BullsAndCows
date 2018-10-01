using BullsAndCows.Business.Models.Contract;

namespace BullsAndCows.Business.Models
{
    public class Cow<TValue> : ICow<TValue>
    {
        public int Index { get; }

        public TValue Value { get; }

        public Cow(int index, TValue value)
        {
            Index = index;
            Value = value;
        }
    }
}