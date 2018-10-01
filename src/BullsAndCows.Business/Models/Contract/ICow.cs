using BullsAndCows.Business.Models.Contract.Supposed;

namespace BullsAndCows.Business.Models.Contract
{
    public interface ICow<out TValue> : IEvaluationResult, ISupposedDigit<TValue>
    {
    }
}