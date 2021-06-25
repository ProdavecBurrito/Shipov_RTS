using UnityEngine;

public class AttackCommand : CommandExecutorBase<IAttackCommand>
{
    public override void ExecuteSpecificCommand<IAttackCommand>(IAttackCommand command)
    {
        Debug.Log("Attack");
    }
}
