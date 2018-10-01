using BullsAndCows.Business.Commands.Contract;
using BullsAndCows.Business.Models.Contract.Secret;
using BullsAndCows.Business.Repositories;

namespace BullsAndCows.Business.Commands
{
    public class RegisterSecretNumber<TValue> : IRegisterSecretNumber<TValue>
    {
        private readonly ISecretNumberRepository _secretNumberRepository;

        public RegisterSecretNumber(ISecretNumberRepository secretNumberRepository)
        {
            _secretNumberRepository = secretNumberRepository;
        }

        public Unit Execute(ISecretNumber<TValue> parameter)
        {
            _secretNumberRepository.Insert(parameter);
            return Unit.Default;
        }
    }
}