using System;
using UniRx;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]
public class SelectableValue : BaseSOValue<ISelectable>, IObservable<ISelectable>
{
    private Subject<ISelectable> _subject = new Subject<ISelectable>();

    public IDisposable Subscribe(IObserver<ISelectable> observer)
    {
        return _subject.Subscribe(observer);
    }
}

