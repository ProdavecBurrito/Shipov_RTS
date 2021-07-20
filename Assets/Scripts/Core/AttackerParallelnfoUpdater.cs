using UnityEngine;
using Zenject;

public class AttackerParallelnfoUpdater : MonoBehaviour, ITickable
{
    [Inject] private IAutomaticAttacker _automaticAttacker;

    public void Tick()
    {
        AutoAttackEvaluator.AttackersInfo.AddOrUpdate(
            gameObject
            , new AutoAttackEvaluator.AttackerParallellnfo(_automaticAttacker.VisionRadius, null)
            , (go, value) =>
            {
                value.VisionRadius = _automaticAttacker.VisionRadius;;
                return value;
            });
    }

    private void OnDestroy()
    {
        AutoAttackEvaluator.AttackersInfo.TryRemove(gameObject, out _);
    }
}
