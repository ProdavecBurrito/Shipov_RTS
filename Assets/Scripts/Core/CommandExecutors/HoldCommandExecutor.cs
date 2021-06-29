
using UnityEngine;

public class HoldCommandExecutor : CommandExecutorBase<IHoldCommand>
{
    public override void ExecuteSpecificCommand<IHoldCommand>(IHoldCommand command)
    {
        Debug.Log("Hold");
    }
}
