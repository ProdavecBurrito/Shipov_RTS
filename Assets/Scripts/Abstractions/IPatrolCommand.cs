using UnityEngine;

public interface IPatrolCommand : ICommand
{
    public Vector3 PatrolVector { get; }
}
