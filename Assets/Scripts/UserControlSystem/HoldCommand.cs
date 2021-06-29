
using UnityEngine;

public class HoldCommand : IHoldCommand
{
    public Vector3 HoldVector { get; }

    public HoldCommand(Vector3 vector)
    {
        HoldVector = vector;
    }
}
