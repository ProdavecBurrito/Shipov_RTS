using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>, IUnitProducer
{
    public IReadOnlyReactiveCollection<IUnitProductionTask> ProductionTaskQueue => _productionTaskQueue;

    [SerializeField] private Transform _unitsParent;
    [SerializeField] private int _maximumUnitsInQueue = 6;

    private ReactiveCollection<IUnitProductionTask> _productionTaskQueue = new ReactiveCollection<IUnitProductionTask>();

    private void Update()
    {
        if (_productionTaskQueue.Count == 0)
        {
            return;
        }

        var innerTask = (UnitProductionTask)_productionTaskQueue[0];
        innerTask.TimeLeft -= Time.deltaTime;
        if (innerTask.TimeLeft <= 0)
        {
            RemoveTaskAtIndex(0);
            Instantiate(innerTask.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        }
    }

    public void Cancel(int index)
    {
        RemoveTaskAtIndex(index);
    }

    private void RemoveTaskAtIndex(int index)
    {
        for (int i = index; i < _productionTaskQueue.Count - 1; i++)
    	{
            _productionTaskQueue[i] = _productionTaskQueue[i + 1];
        }
        _productionTaskQueue.RemoveAt(_productionTaskQueue.Count - 1);
    }

    public override void ExecuteSpecificCommand(IProduceUnitCommand command)
    {
        _productionTaskQueue.Add(new UnitProductionTask(command.ProductionTime, command.Icon, command.UnitPrefab, command.UnitName));
    }
}
