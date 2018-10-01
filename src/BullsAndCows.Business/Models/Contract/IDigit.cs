namespace BullsAndCows.Business.Models.Contract
{
    public interface IDigit<out TValue>
    {
        int Index { get; }

        TValue Value { get; }
    }
}