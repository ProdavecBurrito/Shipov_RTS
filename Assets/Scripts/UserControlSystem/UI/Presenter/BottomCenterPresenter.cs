using UnityEngine;
using Zenject;
using UniRx;
using System;

public class BottomCenterPresenter : MonoBehaviour
{
    [SerializeField] private GameObject _uiHolder;

    private IDisposable _productionQueueAddCt;
    private IDisposable _productionQueueRemoveCt;
    private IDisposable _productionQueueReplaceCt;
    private IDisposable _cancelButtonCts;

    [Inject]
    private void Init(BottomCenterModel model, BottomCenterView view)
    {
        model.UnitProducers.Subscribe(unitProducer =>
        {
            _productionQueueAddCt?.Dispose();
            _productionQueueRemoveCt?.Dispose();
            _productionQueueReplaceCt?.Dispose();
            _cancelButtonCts?.Dispose();

            view.Clear();
            _uiHolder.SetActive(unitProducer != null);

            if (unitProducer != null)
            {
                _productionQueueAddCt = unitProducer.ProductionTaskQueue.ObserveAdd()
                        .Subscribe(addEvent => view.SetTask(addEvent.Value, addEvent.Index));

                _productionQueueRemoveCt = unitProducer.ProductionTaskQueue.ObserveRemove()
                        .Subscribe(removeEvent => view.SetTask(null, removeEvent.Index));

                _productionQueueReplaceCt = unitProducer.ProductionTaskQueue.ObserveReplace()
                        .Subscribe(replaceEvent => view.SetTask(replaceEvent.NewValue, replaceEvent.Index));

                _cancelButtonCts = view.CancelButtonClicks.Subscribe(unitProducer.Cancel);

                for (int i = 0; i < unitProducer.ProductionTaskQueue.Count; i++)
                {
                    view.SetTask(unitProducer.ProductionTaskQueue[i], i);
                }
            }
        });
    }
}
