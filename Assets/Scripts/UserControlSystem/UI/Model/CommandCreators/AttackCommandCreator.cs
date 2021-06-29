	using System;
using UnityEngine;
using Zenject;

public class AttackCommandCreator : CommandCreatorBase<IAttackCommand>
{
	[Inject] private AssetsContext _context;

	private event Action<IAttackCommand> _creationCallback;

	[Inject]
	private void Init(TransformValue target)
	{
		target.OnNewValue += OnNewValue;
	}

	private void OnNewValue(Transform target)
	{
		_creationCallback?.Invoke(_context.Inject(new AttackCommand(target)));
		_creationCallback = null;
	}

	protected override void SpecificCommandCreation(Action<IAttackCommand> creationCallback)
	{
		_creationCallback = creationCallback;
	}

	public override void ProcessCancel()
	{
		base.ProcessCancel();

		_creationCallback = null;
	}
}
