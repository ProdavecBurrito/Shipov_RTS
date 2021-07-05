using UnityEngine;
using UnityEngine.AI;

public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;
    [SerializeField] private HoldCommandExecutor _holdCommand;
    [SerializeField] private NavMeshObstacle _navMeshObstacle;
    [SerializeField] private NavMeshAgent _meshAgent;

    public override async void ExecuteSpecificCommand(IMoveCommand command)
    {
        _meshAgent.destination = command.Target;
        _animator.SetTrigger("Walk");
        _holdCommand.CancellationToken = new System.Threading.CancellationTokenSource();
        try
        {
            await _stop.WithCancellation(_holdCommand.CancellationToken.Token);
        }
        catch
        {
            _meshAgent.isStopped = true;
            _meshAgent.ResetPath();
        }
        _holdCommand.CancellationToken = null;
        _animator.SetTrigger("Idle");
    }
}
