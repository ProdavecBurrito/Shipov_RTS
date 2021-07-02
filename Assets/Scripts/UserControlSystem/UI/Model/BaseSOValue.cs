using System;
using UnityEngine;

public abstract class BaseSOValue<T> : ScriptableObject, IAwaitable<T>
{
    public T CurrentValue { get; private set; }
    public Action<T> OnNewValue;

    public void SetValue(T value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);
    }

    public IAwaiter<T> GetAwaiter()
    {
        return new NewValueNotifier<T>(this);
    }

    public class NewValueNotifier<TAwaited> : BaseAwaiter<TAwaited>
    {
        private readonly BaseSOValue<TAwaited> _scriptableObjectValueBase;

        public NewValueNotifier(BaseSOValue<TAwaited> scriptableObjectValueBase)
        {
            _scriptableObjectValueBase = scriptableObjectValueBase;
            _scriptableObjectValueBase.OnNewValue += OnNewValue;
        }

        public void OnNewValue(TAwaited awaited)
        {
            _scriptableObjectValueBase.OnNewValue -= OnNewValue;
            OnResultValue(awaited);
        }
    }
}
