using BullsAndCows.Business.Models.Contract.Secret;

namespace BullsAndCows.Business.Commands.Contract
{
    public interface IRegisterSecretNumber<in TValue> : ICommand<ISecretNumber<TValue>, Unit>
    {
    }
}