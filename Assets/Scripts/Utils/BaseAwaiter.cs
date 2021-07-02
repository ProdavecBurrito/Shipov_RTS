using System;

public abstract class BaseAwaiter<TAwaiter> : IAwaiter<TAwaiter>
{
    public event Action _continuation; 

    public TAwaiter _result;
    public bool _isCompleted;
    public bool IsCompleted => _isCompleted;
    public TAwaiter GetResult() => _result;

    protected void OnResultValue(TAwaiter awaiter)
    {
        _result = awaiter;
        _isCompleted = true;
        _continuation?.Invoke();
    }

    public void OnCompleted(Action continuation)
    {
        if (_isCompleted)
        {
            continuation?.Invoke();
        }
        else
        {
            _continuation = continuation;
        }
    }
}
