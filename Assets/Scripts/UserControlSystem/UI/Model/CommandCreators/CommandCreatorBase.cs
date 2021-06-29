using System;

public abstract class CommandCreatorBase<T> where T : ICommand
{
    public ICommandExecutor ProcessCommandExecutor(ICommandExecutor commandExecutor, Action<T> callback)
    {
        var classSpecificExecutor = commandExecutor as CommandExecutorBase<T>;
        if (classSpecificExecutor != null)
        {
            SpecificCommandCreation(callback);
        }
        return commandExecutor;
    }

    protected abstract void SpecificCommandCreation(Action<T> creationCallback);

    public virtual void ProcessCancel() { }
}
