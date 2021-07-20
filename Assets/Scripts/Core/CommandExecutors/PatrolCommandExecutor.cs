using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;
    [SerializeField] private HoldCommandExecutor _stopCommandExecutor;

    private Vector3 From;
    private Vector3 To;

    public override async void ExecuteSpecificCommand(IPatrolCommand command)
    {
        From = command.From;
        To = command.To;
        while (true)
        {
            GetComponent<NavMeshAgent>().destination = To;
            _animator.SetTrigger("Walk");
            _stopCommandExecutor.CancellationToken = new CancellationTokenSource();
            try
            {
                await _stop.WithCancellation(_stopCommandExecutor.CancellationToken.Token);
            }
            catch
            {
                GetComponent<NavMeshAgent>().isStopped = true;
                GetComponent<NavMeshAgent>().ResetPath();
                break;
            }

            var temp = From;
            From = To;
            To = temp;
        }
        _stopCommandExecutor.CancellationToken = null;
        _animator.SetTrigger("Idle");
    }
}