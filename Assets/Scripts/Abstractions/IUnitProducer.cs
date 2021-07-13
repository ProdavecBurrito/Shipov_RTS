using UniRx;

public interface IUnitProducer
{
	IReadOnlyReactiveCollection<IUnitProductionTask> ProductionTaskQueue { get; }
	public void Cancel(int index);
}
