using UnityEngine;
using UnityEngine.AI;

public class MainUnit : MonoBehaviour, ISelectable, IAttackable
{
    [SerializeField] Transform _unitTransform;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _maxHealth = 50;
    [SerializeField] private Animator _animator;
    [SerializeField] private HoldCommandExecutor _stopCommand;
    [SerializeField] private int _damage = 25;

    private float _health = 50;

    public float Health => _health;

    public float MaxHealth => _maxHealth;

    public Sprite Icon => _icon;

    public int Damage => _damage;

    public Transform PivotPoint => _unitTransform;

    public void RecieveDamage(int amount)
    {
        if (_health <= 0)
        {
            return;
        }
        _health -= amount;
        if (_health <= 0)
        {
            _animator.SetTrigger("PlayDead");
            Invoke(nameof(Destroy), 1f);
        }
    }

    private void Destroy()
    {
        _stopCommand.ExecuteSpecificCommand(new HoldCommand());
        Destroy(gameObject);
    }
}
