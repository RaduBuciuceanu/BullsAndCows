using BullsAndCows.Business.Models.Contract.Supposed;

namespace BullsAndCows.Business.Builders.Contract
{
    public interface ISupposedNumberBuilder<out TValue>
    {
        ISupposedNumberBuilder<TValue> WithInteger(int integer);

        ISupposedNumber<TValue> Build();
    }
}