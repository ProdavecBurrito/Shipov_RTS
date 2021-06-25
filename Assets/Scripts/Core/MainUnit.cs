using UnityEngine;

public class MainUnit : MonoBehaviour, ISelectable
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _maxHealth = 50;

    private float _health = 50;

    public float Health => _health;

    public float MaxHealth => _maxHealth;

    public Sprite Icon => _icon;
}
