using System;
using BullsAndCows.Business.Commands.Contract.Validations;
using BullsAndCows.Business.Commands.Validations;
using BullsAndCows.Business.Models;
using BullsAndCows.Business.Models.Contract.Supposed;
using Shouldly;
using Xunit;

namespace BullsAndCows.Business.UnitTests.Commands.Validations
{
    public class DistinctDigitsValidationTests
    {
        private readonly IDistinctDigitsValidation<object> _instance;

        public DistinctDigitsValidationTests()
        {
            _instance = new DistinctDigitsValidation<object>();
        }

        [Fact]
        public void Execute_Throws_WhenParameterHasDuplicatedDigits()
        {
            Action act = () => _instance.Execute(BuildWrongNumber());

            act.ShouldThrow<Exception>();
        }

        [Fact]
        public void Execute_DoesNotThrow_WhenParameterHasNoDuplicatedDigits()
        {
            Action act = () => _instance.Execute(BuildRightNumber());

            act.ShouldNotThrow();
        }

        private static ISupposedNumber<object> BuildWrongNumber()
        {
            var duplicate = new object();

            return new SupposedNumber<object>(new[]
            {
                new SupposedDigit<object>(0, duplicate),
                new SupposedDigit<object>(1, duplicate),
            });
        }

        private static ISupposedNumber<object> BuildRightNumber()
        {
            return new SupposedNumber<object>(new[]
            {
                new SupposedDigit<object>(0, new object()),
                new SupposedDigit<object>(1, new object())
            });
        }
    }
}