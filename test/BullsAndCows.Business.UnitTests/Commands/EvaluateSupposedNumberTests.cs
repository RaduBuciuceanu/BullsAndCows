using System.Collections.Generic;
using System.Linq;
using BullsAndCows.Business.Commands;
using BullsAndCows.Business.Commands.Contract;
using BullsAndCows.Business.Commands.Contract.Validations;
using BullsAndCows.Business.Models;
using BullsAndCows.Business.Models.Contract;
using BullsAndCows.Business.Models.Contract.Supposed;
using Moq;
using Shouldly;
using Xunit;

namespace BullsAndCows.Business.UnitTests.Commands
{
    public class EvaluateSupposedNumberTests
    {
        private readonly IEvaluateSupposedNumber<object> _instance;
        private readonly Mock<IEvaluateSupposedDigit<object>> _evaluateSupposedDigit;
        private readonly ISupposedNumber<object> _supposedNumber;
        private readonly IEvaluationResult _digitEvaluationResult;

        public EvaluateSupposedNumberTests()
        {
            _supposedNumber = BuildSupposedNumber();
            _digitEvaluationResult = new Cow<object>(0, _supposedNumber.Digits.First());
            _evaluateSupposedDigit = BuildMockEvaluateSupposedDigit();
            _instance = BuildInstance();
        }

        [Fact]
        public void Execute_CallsEvaluateSupposedDigit_WithEachDigit()
        {
            _instance.Execute(_supposedNumber).ToList();

            foreach (ISupposedDigit<object> digit in _supposedNumber.Digits)
            {
                _evaluateSupposedDigit.Verify(instance => instance.Execute(digit));
            }
        }

        [Fact]
        public void Execute_ReturnsCollectedResults_ReturnedByEvaluateSupposedDigit()
        {
            IEnumerable<IEvaluationResult> actual = _instance.Execute(_supposedNumber);

            actual.ShouldContain(_digitEvaluationResult);
        }

        private EvaluateSupposedNumber<object> BuildInstance()
        {
            return new EvaluateSupposedNumber<object>(
                _evaluateSupposedDigit.Object,
                Mock.Of<IDistinctDigitsValidation<object>>());
        }

        private Mock<IEvaluateSupposedDigit<object>> BuildMockEvaluateSupposedDigit()
        {
            var mock = new Mock<IEvaluateSupposedDigit<object>>();

            mock
                .Setup(instance => instance.Execute(It.IsAny<ISupposedDigit<object>>()))
                .Returns(_digitEvaluationResult);

            return mock;
        }

        private static ISupposedNumber<object> BuildSupposedNumber()
        {
            var supposedDigit = new SupposedDigit<object>(0, new object());
            return new SupposedNumber<object>(new[] {supposedDigit});
        }
    }
}