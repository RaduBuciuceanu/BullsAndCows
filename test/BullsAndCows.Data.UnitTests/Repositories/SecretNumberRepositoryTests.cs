using System.Collections.Generic;
using BullsAndCows.Business.Models;
using BullsAndCows.Business.Models.Contract.Secret;
using BullsAndCows.Business.Repositories;
using BullsAndCows.Data.Repositories;
using Shouldly;
using Xunit;

namespace BullsAndCows.Data.UnitTests.Repositories
{
    public class SecretNumberRepositoryTests
    {
        private readonly ISecretNumberRepository _instance;
        private readonly ISecretNumber<int> _secretNumber;

        public SecretNumberRepositoryTests()
        {
            _instance = new SecretNumberRepository();
            _secretNumber = new SecretNumber<int>(new List<ISecretDigit<int>>());
        }

        [Fact]
        public void Insert_Returns_InsertedModel()
        {
            ISecretNumber<int> actual = _instance.Insert(_secretNumber);

            actual.ShouldBe(_secretNumber);
        }

        [Fact]
        public void Get_Returns_InsertedModel()
        {
            _instance.Insert(_secretNumber);

            ISecretNumber<int> actual = _instance.Get<int>();

            actual.ShouldBe(_secretNumber);
        }
    }
}