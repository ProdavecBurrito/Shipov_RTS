using UnityEngine;

public class MainBuilding : MonoBehaviour, ISelectable, IAttackable
{
	[SerializeField] private Transform _buildingTransform;
	[SerializeField] private Transform _unitsParent;

	[SerializeField] private Sprite _icon;
	[SerializeField] private float _maxHealth = 1000;
	[SerializeField] private Vector3 _departurePoint;

	private float _health = 1000;

	public float Health => _health;
	public float MaxHealth => _maxHealth;
	public Sprite Icon => _icon;
	public Transform PivotPoint => _buildingTransform;
	public Vector3 DeparturePoint => _departurePoint;

	public void SetDeparturePoint(Vector3 point)
    {
		_departurePoint = point;
    }
}