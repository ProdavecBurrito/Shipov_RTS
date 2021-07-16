using System;
using System.Threading;
using System.Threading.Tasks;
using Zenject;

public class ProduceUnitCommandCreator : CommandCreatorBase<IProduceUnitCommand>
{
    [Inject] private AssetsContext _context;
    [Inject] private DiContainer _diContainer;

    protected override void SpecificCommandCreation(Action<IProduceUnitCommand> creationCallback)
    {
        var produceUnitCommand = _context.Inject(new ProduceUnitCommand());
        _diContainer.Inject(produceUnitCommand);
        creationCallback?.Invoke(produceUnitCommand);

    }
}
