using BullsAndCows.Business.Models.Contract;

namespace BullsAndCows.Business.Models
{
    public class Bull<TValue> : IBull<TValue>
    {
        public int Index { get; }

        public TValue Value { get; }

        public Bull(int index, TValue value)
        {
            Index = index;
            Value = value;
        }
    }
}