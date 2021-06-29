using UnityEngine;

public class AttackCommand : IAttackCommand
{
    public Transform AttackTarget { get; }

    public AttackCommand(Transform target)
    {
        AttackTarget = target;
    }
}
