using BullsAndCows.Business.Models.Contract.Supposed;

namespace BullsAndCows.Business.Models.Contract
{
    public interface IBull<out TValue> : IEvaluationResult, ISupposedDigit<TValue>
    {
    }
}