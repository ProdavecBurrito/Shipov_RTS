
using UnityEngine;

public class HoldCommand : CommandExecutorBase<IHoldCommand>
{
    public override void ExecuteSpecificCommand<IHoldCommand>(IHoldCommand command)
    {
        Debug.Log("Hold");
    }
}
