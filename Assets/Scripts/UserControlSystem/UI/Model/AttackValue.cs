using UnityEngine;
using System;

[CreateAssetMenu(fileName = nameof(AttackValue), menuName = "Strategy Game/" + nameof(AttackValue), order = 0)]
public class AttackValue : BaseSOValue<IAttackable>
{
}
