using UnityEngine;
using UniRx;

public class AutoAttackAgent : MonoBehaviour
{
    [SerializeField] private AttackCommandExecutor _queue;

    private void Start()
    {
        AutoAttackEvaluator.AutoAttackCommands
            .ObserveOnMainThread()
            .Where(command => command.Attacker == gameObject)
            .Where(command => command.Attacker != null && command.Target != null)
            .Subscribe(command => AutoAttack(command.Target))
            .AddTo(this);
    }

    private void AutoAttack(GameObject target)
    {
        _queue.ExecuteSpecificCommand(new AutoAttackCommand(target.GetComponent<IAttackable>()));
    }
}
