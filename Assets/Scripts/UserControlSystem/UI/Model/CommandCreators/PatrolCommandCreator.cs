using Zenject;
using System;
using UnityEngine;

public class PatrolCommandCreator : CommandCreatorBase<IPatrolCommand>
{
	[Inject] private AssetsContext _context;

	private event Action<IPatrolCommand> _creationCallback;

	[Inject]
	private void Init(Vector3Value target)
	{
		target.OnNewValue += OnNewValue;
	}

	private void OnNewValue(Vector3 target)
	{
		_creationCallback?.Invoke(_context.Inject(new PatrolCommand(target)));
		_creationCallback = null;
	}

	protected override void SpecificCommandCreation(Action<IPatrolCommand> creationCallback)
	{
		_creationCallback = creationCallback;
	}

	public override void ProcessCancel()
	{
		base.ProcessCancel();

		_creationCallback = null;
	}
}
