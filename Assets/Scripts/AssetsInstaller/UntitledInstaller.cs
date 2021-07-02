using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "UntitledInstaller", menuName = "Installers/UntitledInstaller")]
public class UntitledInstaller : ScriptableObjectInstaller<UntitledInstaller>
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private Vector3Value _groudClickRMB;
    [SerializeField] private AttackValue _attackTargetRMB;
    [SerializeField] private SelectableValue _selectableValue;

    public override void InstallBindings()
    {
        Container.BindInstances(_legacyContext, _groudClickRMB, _attackTargetRMB, _selectableValue);
        Container.Bind<IAwaitable<IAttackable>>().FromInstance(_attackTargetRMB);
        Container.Bind<IAwaitable<Vector3>>().FromInstance(_groudClickRMB);
    }
}