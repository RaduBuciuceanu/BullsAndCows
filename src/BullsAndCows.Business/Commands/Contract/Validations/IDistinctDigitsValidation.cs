using BullsAndCows.Business.Models.Contract.Supposed;

namespace BullsAndCows.Business.Commands.Contract.Validations
{
    public interface IDistinctDigitsValidation<in TValue> : ICommand<ISupposedNumber<TValue>, Unit>
    {
    }
}