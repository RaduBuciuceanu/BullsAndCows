using BullsAndCows.Business.Models.Contract.Secret;
using BullsAndCows.Business.Repositories;

namespace BullsAndCows.Data.Repositories
{
    public class SecretNumberRepository : ISecretNumberRepository
    {
        private object _secretNumber;

        public ISecretNumber<TValue> Insert<TValue>(ISecretNumber<TValue> secretNumber)
        {
            _secretNumber = secretNumber;
            return secretNumber;
        }

        public ISecretNumber<TValue> Get<TValue>()
        {
            return (ISecretNumber<TValue>) _secretNumber;
        }
    }
}