using BullsAndCows.Business.Models.Contract.Secret;

namespace BullsAndCows.Business.Repositories
{
    public interface ISecretNumberRepository
    {
        ISecretNumber<TValue> Insert<TValue>(ISecretNumber<TValue> secretNumber);

        ISecretNumber<TValue> Get<TValue>();
    }
}