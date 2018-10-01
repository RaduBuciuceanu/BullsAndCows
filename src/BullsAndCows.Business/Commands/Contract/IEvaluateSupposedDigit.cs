using BullsAndCows.Business.Models.Contract;
using BullsAndCows.Business.Models.Contract.Supposed;

namespace BullsAndCows.Business.Commands.Contract
{
    public interface IEvaluateSupposedDigit<in TValue> : ICommand<ISupposedDigit<TValue>, IEvaluationResult>
    {
    }
}