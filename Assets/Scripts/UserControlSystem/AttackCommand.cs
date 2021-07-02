using UnityEngine;

public class AttackCommand : IAttackCommand
{
    public IAttackable AttackTarget { get; }

    public AttackCommand(IAttackable target)
    {
        AttackTarget = target;
    }
}
