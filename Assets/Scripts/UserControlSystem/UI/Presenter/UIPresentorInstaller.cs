using Zenject;

public class UIPresentorInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<BottomCenterPresenter>().FromComponentInHierarchy().AsSingle();
    }
}
