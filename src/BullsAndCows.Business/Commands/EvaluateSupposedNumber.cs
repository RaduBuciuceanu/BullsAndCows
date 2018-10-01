using System.Collections.Generic;
using BullsAndCows.Business.Commands.Contract;
using BullsAndCows.Business.Commands.Contract.Validations;
using BullsAndCows.Business.Models.Contract;
using BullsAndCows.Business.Models.Contract.Supposed;

namespace BullsAndCows.Business.Commands
{
    public class EvaluateSupposedNumber<TValue> : IEvaluateSupposedNumber<TValue>
    {
        private readonly IEvaluateSupposedDigit<TValue> _evaluateSupposedDigit;
        private readonly IDistinctDigitsValidation<TValue> _distinctDigitsValidation;

        public EvaluateSupposedNumber(IEvaluateSupposedDigit<TValue> evaluateSupposedDigit, 
            IDistinctDigitsValidation<TValue> distinctDigitsValidation)
        {
            _evaluateSupposedDigit = evaluateSupposedDigit;
            _distinctDigitsValidation = distinctDigitsValidation;
        }

        public IEnumerable<IEvaluationResult> Execute(ISupposedNumber<TValue> parameter)
        {
            _distinctDigitsValidation.Execute(parameter);
            
            foreach (ISupposedDigit<TValue> supposedDigit in parameter.Digits)
            {
                yield return _evaluateSupposedDigit.Execute(supposedDigit);
            }
        }
    }
}