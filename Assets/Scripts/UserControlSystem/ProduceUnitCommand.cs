using UnityEngine;
using Zenject;

public class ProduceUnitCommand : IProduceUnitCommand
{
    [Inject(Id = "Chomper")] public string UnitName { get; }
    [Inject(Id = "Chomper")] public float ProductionTime { get; }
    [Inject(Id = "Chomper")] public Sprite Icon { get; }


    [InjectAsset("Chomper")] private GameObject _unitPrefab;
    public GameObject UnitPrefab => _unitPrefab;
}
