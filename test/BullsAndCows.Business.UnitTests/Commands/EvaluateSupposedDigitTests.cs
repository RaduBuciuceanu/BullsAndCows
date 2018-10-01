using BullsAndCows.Business.Commands;
using BullsAndCows.Business.Commands.Contract;
using BullsAndCows.Business.Models;
using BullsAndCows.Business.Models.Contract;
using BullsAndCows.Business.Models.Contract.Secret;
using BullsAndCows.Business.Repositories;
using Moq;
using Shouldly;
using Xunit;

namespace BullsAndCows.Business.UnitTests.Commands
{
    public class EvaluateSupposedDigitTests
    {
        private readonly IEvaluateSupposedDigit<object> _instance;
        private readonly Mock<ISecretNumberRepository> _repository;
        private readonly object _value;

        public EvaluateSupposedDigitTests()
        {
            _value = new object();
            _repository = BuildMockRepository();
            _instance = new EvaluateSupposedDigit<object>(_repository.Object);
        }

        [Fact]
        public void Execute_CallsGet_FromRepository()
        {
            var rightDigit = new SupposedDigit<object>(0, _value);

            _instance.Execute(rightDigit);

            _repository.Verify(instance => instance.Get<object>());
        }

        [Fact]
        public void Execute_ReturnsBull_WhenSupposedDigitIsRight()
        {
            var rightDigit = new SupposedDigit<object>(0, _value);

            IEvaluationResult actual = _instance.Execute(rightDigit);

            actual.ShouldBeOfType<Bull<object>>();
        }

        [Fact]
        public void Execute_ReturnsCow_WhenIndexIsWrong()
        {
            var cowDigit = new SupposedDigit<object>(1, _value);

            IEvaluationResult actual = _instance.Execute(cowDigit);

            actual.ShouldBeOfType<Cow<object>>();
        }

        [Fact]
        public void Execute_ReturnsEmpty_WhenSupposedDigitIsWrong()
        {
            var wrongDigit = new SupposedDigit<object>(1, new object());

            IEvaluationResult actual = _instance.Execute(wrongDigit);

            actual.ShouldBeOfType<EmptyEvaluationResult>();
        }

        private Mock<ISecretNumberRepository> BuildMockRepository()
        {
            var mock = new Mock<ISecretNumberRepository>();

            mock
                .Setup(instance => instance.Get<object>())
                .Returns(BuildSecretNumber());

            return mock;
        }

        private ISecretNumber<object> BuildSecretNumber()
        {
            return new SecretNumber<object>(new[]
            {
                new SecretDigit<object>(0, _value),
                new SecretDigit<object>(1, new object())
            });
        }
    }
}