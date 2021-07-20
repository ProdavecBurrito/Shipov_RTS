using UniRx;
using UnityEngine;
using UnityEngine.AI;

public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>, ICommandTask
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;
    [SerializeField] private HoldCommandExecutor _holdCommand;
    [SerializeField] private NavMeshAgent _meshAgent;

    public ReactiveCollection<IMoveCommand> _moveCommands = new ReactiveCollection<IMoveCommand>();
    public IReadOnlyReactiveCollection<IMoveCommand> MoveCommands => _moveCommands;

    private void Update()
    {
        if (_moveCommands.Count == 0)
        {
            return;
        }

        var innerTask = (IMoveCommand)_moveCommands[0];
        if (_meshAgent.isStopped)
        {
            RemoveTaskAtIndex(0);
        }
    }


    public void Cancel()
    {
        throw new System.NotImplementedException();
    }

    public override async void ExecuteSpecificCommand(IMoveCommand command)
    {
        _moveCommands.Add(command);
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
    private void RemoveTaskAtIndex(int index)
    {
        for (int i = index; i < _moveCommands.Count - 1; i++)
        {
            _moveCommands[i] = _moveCommands[i + 1];
        }
        _moveCommands.RemoveAt(_moveCommands.Count - 1);
    }
}
