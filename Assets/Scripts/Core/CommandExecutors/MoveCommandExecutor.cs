using UnityEngine;
using UnityEngine.AI;

public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;
    [SerializeField] private HoldCommandExecutor _holdCommand;
    [SerializeField] private NavMeshObstacle _navMeshObstacle;

    public override async void ExecuteSpecificCommand(IMoveCommand command)
    {
        GetComponent<NavMeshAgent>().destination = command.Target;
        _animator.SetTrigger("Walk");
        _navMeshObstacle.enabled = false;
        _holdCommand.CancellationToken = new System.Threading.CancellationTokenSource();
        await _stop.WithCancellation(_holdCommand.CancellationToken.Token);
        _holdCommand.CancellationToken = null;
        _animator.SetTrigger("Idle");
        _navMeshObstacle.enabled = true;
    }
}
