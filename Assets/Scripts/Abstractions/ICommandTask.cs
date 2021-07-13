using UniRx;

public interface ICommandTask
{
    IReadOnlyReactiveCollection<IMoveCommand> MoveCommands { get; }
    public void Cancel();
}