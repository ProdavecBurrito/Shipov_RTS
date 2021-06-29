using UnityEngine;

public interface IHoldCommand : ICommand
{
    public Vector3 HoldVector { get; }
}
