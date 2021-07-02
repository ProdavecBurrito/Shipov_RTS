using System;
using System.Threading;
using Zenject;

public class AttackCommandCreator : CancellableCommandCreatorBase<IAttackCommand, IAttackable>
{
	[Inject] private AssetsContext _context;
	[Inject] private AttackValue _groundClicks;

    private CancellationTokenSource _ctSource;

    protected override IAttackCommand CreateCommand(IAttackable argument)
    {
        return new AttackCommand(argument);
    }
}
