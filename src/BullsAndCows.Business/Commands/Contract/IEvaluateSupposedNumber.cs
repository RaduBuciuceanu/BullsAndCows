using System.Collections.Generic;
using BullsAndCows.Business.Models.Contract;
using BullsAndCows.Business.Models.Contract.Supposed;

namespace BullsAndCows.Business.Commands.Contract
{
    public interface IEvaluateSupposedNumber<in TValue> :
        ICommand<ISupposedNumber<TValue>, IEnumerable<IEvaluationResult>>
    {
    }
}