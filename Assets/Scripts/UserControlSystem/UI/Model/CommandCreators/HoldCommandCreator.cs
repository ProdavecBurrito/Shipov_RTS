using UnityEngine;

public class HoldCommandCreator : CancellableCommandCreatorBase<IHoldCommand, Vector3>
{
    protected override IHoldCommand CreateCommand(Vector3 arg)
    {
        return new HoldCommand(arg);
    }
}
