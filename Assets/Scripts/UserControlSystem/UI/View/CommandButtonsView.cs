using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CommandButtonsView : MonoBehaviour
{
	public Action<ICommandExecutor> OnClick;

	[SerializeField] private GameObject _attackButton;
	[SerializeField] private GameObject _moveButton;
	[SerializeField] private GameObject _patrolButton;
	[SerializeField] private GameObject _stopButton;
	[SerializeField] private GameObject _produceUnitButton;
	[SerializeField] private GameObject _depaturePointButton;

	private Dictionary<Type, GameObject> _buttonsByExecutorType;

	private void Awake()
	{
		_buttonsByExecutorType = new Dictionary<Type, GameObject>();
		_buttonsByExecutorType.Add(typeof(CommandExecutorBase<IAttackCommand>), _attackButton);
		_buttonsByExecutorType.Add(typeof(CommandExecutorBase<IMoveCommand>), _moveButton);
		_buttonsByExecutorType.Add(typeof(CommandExecutorBase<IPatrolCommand>), _patrolButton);
		_buttonsByExecutorType.Add(typeof(CommandExecutorBase<IHoldCommand>), _stopButton);
		_buttonsByExecutorType.Add(typeof(CommandExecutorBase<IProduceUnitCommand>), _produceUnitButton);
		_buttonsByExecutorType.Add(typeof(CommandExecutorBase<IDeparturePoint>), _depaturePointButton);
	}

	public void BlockInteractions(ICommandExecutor executor)
	{
		UnblockAllInteractions();
		GetButtonGameObjectByType(executor.GetType()).GetComponent<Selectable>().interactable = false;
	}

    public void UnblockAllInteractions()
    {
        SetInteractible(true);
    }

    private void SetInteractible(bool value)
	{
		_attackButton.GetComponent<Selectable>().interactable = value;
		_moveButton.GetComponent<Selectable>().interactable = value;
		_patrolButton.GetComponent<Selectable>().interactable = value;
		_stopButton.GetComponent<Selectable>().interactable = value;
		_produceUnitButton.GetComponent<Selectable>().interactable = value;
		_depaturePointButton.GetComponent<Selectable>().interactable = value;
	}

	private GameObject GetButtonGameObjectByType(Type executorInstanceType)
	{
		return _buttonsByExecutorType.Where(type => type.Key.IsAssignableFrom(executorInstanceType)).First().Value;
	}

	public void MakeLayout(IEnumerable<ICommandExecutor> commandExecutors)
	{
		foreach (var currentExecutor in commandExecutors)
		{
			var buttonGameObject = _buttonsByExecutorType.Where(type => type.Key.IsAssignableFrom(currentExecutor.GetType())).First().Value;
			buttonGameObject.SetActive(true);
			var button = buttonGameObject.GetComponent<Button>();
			button.onClick.AddListener(() => OnClick?.Invoke(currentExecutor));
		}
	}

	public void Clear()
	{
		foreach (var kvp in _buttonsByExecutorType)
		{
			kvp.Value.GetComponent<Button>().onClick.RemoveAllListeners();
			kvp.Value.SetActive(false);
		}
	}
}

