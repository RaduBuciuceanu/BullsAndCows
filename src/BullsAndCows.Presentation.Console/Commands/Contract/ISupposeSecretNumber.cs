using BullsAndCows.Business.Commands.Contract;

namespace BullsAndCows.Presentation.Console.Commands.Contract
{
    public interface ISupposeSecretNumber : ICommand<Unit, Unit>
    {
    }
}