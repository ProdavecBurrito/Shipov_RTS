using UnityEngine;

public interface IAttackCommand : ICommand
{
    public Transform AttackTarget { get; }
}
