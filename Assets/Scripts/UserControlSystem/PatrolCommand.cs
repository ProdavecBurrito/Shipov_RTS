
using UnityEngine;

public class PatrolCommand : CommandExecutorBase<IPatrolCommand>
{
    public override void ExecuteSpecificCommand<IPatrolCommand>(IPatrolCommand command)
    {
        Debug.Log("Patrol");
    }
}
