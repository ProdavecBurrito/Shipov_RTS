using UnityEngine;

public class MoveCommand : CommandExecutorBase<IMoveCommand>
{
    public override void ExecuteSpecificCommand<IMoveCommand>(IMoveCommand command)
    {
        Debug.Log("Move");
    }
}
