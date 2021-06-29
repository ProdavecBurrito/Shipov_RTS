using UnityEngine;

public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
{
    public override void ExecuteSpecificCommand<IAttackCommand>(IAttackCommand command)
    {
        Debug.Log($"{name} is attaking {command}");
    }
}
