using UnityEngine;
using System.Threading;

public class HoldCommandExecutor : CommandExecutorBase<IHoldCommand>
{
    public CancellationTokenSource CancellationToken;

    public override void ExecuteSpecificCommand(IHoldCommand command)
    {
        CancellationToken?.Cancel();
    }
}
