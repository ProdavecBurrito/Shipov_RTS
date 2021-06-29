using UnityEngine;
using Zenject;

public class UiModelInstaller : MonoInstaller
{
	[SerializeField] private AssetsContext _legacyContext;
	[SerializeField] private Vector3Value _vector3Value;
	[SerializeField] private TransformValue _transformValue;
	[SerializeField] private SelectableValue _selectableValue;

    public override void InstallBindings()
	{
		Container.Bind<AssetsContext>().FromInstance(_legacyContext);
        Container.Bind<Vector3Value>().FromInstance(_vector3Value);
		Container.Bind<TransformValue>().FromInstance(_transformValue);
		Container.Bind<SelectableValue>().FromInstance(_selectableValue);

		Container.Bind<CommandCreatorBase<IProduceUnitCommand>>().To<ProduceUnitCommandCreator>().AsTransient();
		Container.Bind<CommandCreatorBase<IAttackCommand>>().To<AttackCommandCreator>().AsTransient();
		Container.Bind<CommandCreatorBase<IMoveCommand>>().To<MoveCommandCreator>().AsTransient();
		Container.Bind<CommandCreatorBase<IPatrolCommand>>().To<PatrolCommandCreator>().AsTransient();
		Container.Bind<CommandCreatorBase<IHoldCommand>>().To<HoldCommandCreator>().AsTransient();

		Container.Bind<CommandButtonsModel>().AsTransient();
	}

}
