using System;
using System.Collections.Generic;
using System.Linq;
using BullsAndCows.Business.Builders;
using BullsAndCows.Business.Builders.Contract;
using BullsAndCows.Business.Models;
using BullsAndCows.Business.Models.Contract.Supposed;
using Shouldly;
using Xunit;

namespace BullsAndCows.Business.UnitTests.Builders
{
    public class SupposedNumberBuilderTests
    {
        private readonly ISupposedNumberBuilder<int> _instance;
        private readonly int _integer;
        private readonly IEnumerable<ISupposedDigit<int>> _expectedDigits;

        public SupposedNumberBuilderTests()
        {
            _integer = 1234;
            _expectedDigits = BuildExpectedDigits();
            _instance = new SupposedNumberBuilder<int>();
        }

        [Fact]
        public void WithInteger_Returns_Itself()
        {
            ISupposedNumberBuilder<int> actual = _instance.WithInteger(_integer);

            actual.ShouldBe(_instance);
        }

        [Fact]
        public void WithInteger_DividedDigits_HaveRightValues()
        {
            ISupposedNumber<int> actual = _instance.WithInteger(_integer).Build();

            DigitsAssert(actual, (actualDigit, expectedDigit) => actualDigit.Value.ShouldBe(expectedDigit.Value));
        }

        [Fact]
        public void WithInteger_DividedDigits_HaveRightIndexes()
        {
            ISupposedNumber<int> actual = _instance.WithInteger(_integer).Build();

            DigitsAssert(actual, (actualDigit, expectedDigit) => actualDigit.Index.ShouldBe(expectedDigit.Index));
        }

        [Fact]
        public void Build_DoesNot_ReturnNull()
        {
            ISupposedNumber<int> actual = _instance.Build();

            actual.ShouldNotBeNull();
        }

        private void DigitsAssert(ISupposedNumber<int> actual,
            Action<ISupposedDigit<int>, ISupposedDigit<int>> condition)
        {
            for (int index = 0; index < _expectedDigits.Count(); index++)
            {
                ISupposedDigit<int> expectedDigit = _expectedDigits.ElementAt(index);
                ISupposedDigit<int> actualDigit = actual.Digits.ElementAt(index);

                condition(actualDigit, expectedDigit);
            }
        }

        private static SupposedDigit<int>[] BuildExpectedDigits()
        {
            return new[]
            {
                new SupposedDigit<int>(0, 1),
                new SupposedDigit<int>(1, 2),
                new SupposedDigit<int>(2, 3),
                new SupposedDigit<int>(3, 4)
            };
        }
    }
}