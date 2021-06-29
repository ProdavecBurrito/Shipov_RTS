using System;
using UnityEngine;
using Zenject;

public class HoldCommandCreator : CommandCreatorBase<IHoldCommand>
{
	[Inject] private AssetsContext _context;

	private event Action<IHoldCommand> _creationCallback;

	[Inject]
	private void Init(Vector3Value vector3)
	{
		vector3.OnNewValue += OnNewValue;
	}

	private void OnNewValue(Vector3 value)
	{
		_creationCallback?.Invoke(_context.Inject(new HoldCommand(value)));
		_creationCallback = null;
	}

	protected override void SpecificCommandCreation(Action<IHoldCommand> creationCallback)
	{
		_creationCallback = creationCallback;
	}

	public override void ProcessCancel()
	{
		base.ProcessCancel();

		_creationCallback = null;
	}
}
