using BullsAndCows.Business.Models.Contract.Secret;

namespace BullsAndCows.Business.Builders.Contract
{
    public interface ISecretNumberBuilder<out TValue>
    {
        ISecretNumberBuilder<TValue> WithInteger(int integer);

        ISecretNumber<TValue> Build();
    }
}