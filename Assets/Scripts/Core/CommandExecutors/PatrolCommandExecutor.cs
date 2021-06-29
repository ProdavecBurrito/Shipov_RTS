using UnityEngine;

public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
{
    public override void ExecuteSpecificCommand<IPatrolCommand>(IPatrolCommand command)
    {
        Debug.Log($"{name} is patrol to {command}");
    }
}
