using Zenject;

public class UiModelInstaller : MonoInstaller
{
    public override void InstallBindings()
	{
		Container.Bind<CommandCreatorBase<IProduceUnitCommand>>().To<ProduceUnitCommandCreator>().AsTransient();
		Container.Bind<CommandCreatorBase<IAttackCommand>>().To<AttackCommandCreator>().AsTransient();
		Container.Bind<CommandCreatorBase<IMoveCommand>>().To<MoveCommandCreator>().AsTransient();
		Container.Bind<CommandCreatorBase<IPatrolCommand>>().To<PatrolCommandCreator>().AsTransient();
		Container.Bind<CommandCreatorBase<IHoldCommand>>().To<HoldCommandCreator>().AsTransient();

		Container.Bind<CommandButtonsModel>().AsSingle();

		Container.Bind<float>().WithId("Chomper").FromInstance(3.0f);
		Container.Bind<string>().WithId("Chomper").FromInstance("Chomper");
	}

}
