using System;
using UnityEngine;

public class BaseSOValue<T> : ScriptableObject
{
	public event Action<T> OnNewValue;

	public T CurrentValue { get; private set; }

	public void SetValue(T value)
	{
		CurrentValue = value;
		OnNewValue?.Invoke(value);
	}
}
