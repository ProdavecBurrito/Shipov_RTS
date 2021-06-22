using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]
public class SelectableValue : ScriptableObject
{
	public Action<ISelectable> OnSelected = delegate (ISelectable selectable) { };

	public ISelectable CurrentValue { get; private set; }

	public void SetValue(ISelectable value)
	{
		CurrentValue = value;
		OnSelected.Invoke(value);
	}
}

