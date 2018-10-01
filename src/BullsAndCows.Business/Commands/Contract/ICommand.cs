namespace BullsAndCows.Business.Commands.Contract
{
    public interface ICommand<in TInput, out TOutput>
    {
        TOutput Execute(TInput parameter);
    }
}