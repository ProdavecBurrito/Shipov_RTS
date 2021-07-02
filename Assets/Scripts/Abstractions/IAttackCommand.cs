using UnityEngine;

public interface IAttackCommand : ICommand
{
    public IAttackable AttackTarget { get; }
}
