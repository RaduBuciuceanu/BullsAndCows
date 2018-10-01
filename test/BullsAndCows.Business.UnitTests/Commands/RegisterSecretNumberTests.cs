using System.Collections.Generic;
using BullsAndCows.Business.Commands;
using BullsAndCows.Business.Commands.Contract;
using BullsAndCows.Business.Models;
using BullsAndCows.Business.Models.Contract.Secret;
using BullsAndCows.Business.Repositories;
using Moq;
using Xunit;

namespace BullsAndCows.Business.UnitTests.Commands
{
    public class RegisterSecretNumberTests
    {
        private readonly IRegisterSecretNumber<int> _instance;
        private readonly Mock<ISecretNumberRepository> _repository;

        public RegisterSecretNumberTests()
        {
            _repository = new Mock<ISecretNumberRepository>();
            _instance = new RegisterSecretNumber<int>(_repository.Object);
        }

        [Fact]
        public void Execute_CallsInsert_FromRepository()
        {
            var expected = new SecretNumber<int>(new List<ISecretDigit<int>>());

            _instance.Execute(expected);

            _repository.Verify(instance => instance.Insert(expected));
        }
    }
}