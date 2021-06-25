using UnityEngine;

public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable
{
	[SerializeField] private GameObject _unitPrefab;
	[SerializeField] private Transform _unitsParent;

	[SerializeField] private Sprite _icon;
	[SerializeField] private float _maxHealth = 1000;

	private float _health = 1000;

	public float Health => _health;
	public float MaxHealth => _maxHealth;
	public Sprite Icon => _icon;

    public override void ExecuteSpecificCommand<IProduceUnitCommand>(IProduceUnitCommand command)
    {
		Instantiate(_unitPrefab, new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)), Quaternion.identity, _unitsParent);
	}
}