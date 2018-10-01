using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BullsAndCows.Business.Builders;
using BullsAndCows.Business.Builders.Contract;
using BullsAndCows.Business.Models;
using BullsAndCows.Business.Models.Contract.Secret;
using Shouldly;
using Xunit;

namespace BullsAndCows.Business.UnitTests.Builders
{
    public class SecretNumberBuilderTests
    {
        private readonly ISecretNumberBuilder<int> _instance;
        private readonly int _integer;
        private readonly IEnumerable<ISecretDigit<int>> _expectedDigits;

        public SecretNumberBuilderTests()
        {
            _integer = 1234;
            _expectedDigits = BuildExpectedDigits();
            _instance = new SecretNumberBuilder<int>();
        }

        [Fact]
        public void WithInteger_Returns_Itself()
        {
            ISecretNumberBuilder<int> actual = _instance.WithInteger(_integer);

            actual.ShouldBe(_instance);
        }

        [Fact]
        public void WithInteger_DividedDigits_HaveRightValues()
        {
            ISecretNumber<int> actual = _instance.WithInteger(_integer).Build();

            DigitsAssert(actual, (actualDigit, expectedDigit) => actualDigit.Value.ShouldBe(expectedDigit.Value));
        }

        [Fact]
        public void WithInteger_DividedDigits_HaveRightIndexes()
        {
            ISecretNumber<int> actual = _instance.WithInteger(_integer).Build();

            DigitsAssert(actual, (actualDigit, expectedDigit) => actualDigit.Index.ShouldBe(expectedDigit.Index));
        }

        [Fact]
        public void Build_DoesNot_ReturnNull()
        {
            ISecretNumber<int> actual = _instance.Build();

            actual.ShouldNotBeNull();
        }

        private void DigitsAssert(ISecretNumber<int> actual, Action<ISecretDigit<int>, ISecretDigit<int>> condition)
        {
            for (int index = 0; index < _expectedDigits.Count(); index++)
            {
                ISecretDigit<int> expectedDigit = _expectedDigits.ElementAt(index);
                ISecretDigit<int> actualDigit = actual.Digits.ElementAt(index);

                condition(actualDigit, expectedDigit);
            }
        }

        private static SecretDigit<int>[] BuildExpectedDigits()
        {
            return new[]
            {
                new SecretDigit<int>(0, 1),
                new SecretDigit<int>(1, 2),
                new SecretDigit<int>(2, 3),
                new SecretDigit<int>(3, 4)
            };
        }
    }
}