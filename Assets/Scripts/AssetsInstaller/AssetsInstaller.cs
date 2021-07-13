using UnityEngine;
using Zenject;
using System;

[CreateAssetMenu(fileName = "UntitledInstaller", menuName = "Installers/UntitledInstaller")]
public class AssetsInstaller : ScriptableObjectInstaller<AssetsInstaller>
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private Vector3Value _groudClickRMB;
    [SerializeField] private AttackValue _attackTargetRMB;
    [SerializeField] private SelectableValue _selectableValue;
    [SerializeField] private Sprite _chomperSprite;

    public override void InstallBindings()
    {
        Container.BindInstances(_legacyContext, _groudClickRMB, _attackTargetRMB, _selectableValue);
        Container.Bind<IAwaitable<IAttackable>>().FromInstance(_attackTargetRMB);
        Container.Bind<IAwaitable<Vector3>>().FromInstance(_groudClickRMB);
        Container.Bind<IObservable<ISelectable>>().FromInstance(_selectableValue);
        Container.Bind<Sprite>().WithId("Chomper").FromInstance(_chomperSprite);
    }
}