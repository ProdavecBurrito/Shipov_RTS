
using UnityEngine;

public class PatrolCommand : IPatrolCommand
{
    public Vector3 PatrolVector { get; }

    public PatrolCommand(Vector3 patrolVector)
	{
        PatrolVector = patrolVector;
	}
}
