using UnityEngine;
using UnityEngine.AI;

public class MainUnit : MonoBehaviour, ISelectable, IAttackable
{
    [SerializeField] Transform _unitTransform;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _maxHealth = 50;

    private float _health = 50;

    public float Health => _health;

    public float MaxHealth => _maxHealth;

    public Sprite Icon => _icon;

    public Transform PivotPoint => _unitTransform;
}
