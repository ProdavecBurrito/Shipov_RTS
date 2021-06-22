using UnityEngine;

public class MainBuilding : MonoBehaviour, IUnitProducer, ISelectable
{
	[SerializeField] private GameObject _unitPrefab;
	[SerializeField] private Transform _unitsParent;

	[SerializeField] private Sprite _icon;
	[SerializeField] private float _maxHealth = 1000;

	[SerializeField] private Shader _baseShader;
	[SerializeField] private Shader _selectedShader;
	[SerializeField] private Renderer _renderer;

	private float _health = 1000;

	public float Health => _health;
	public float MaxHealth => _maxHealth;
	public Sprite Icon => _icon;
	public Shader BaseShader => _baseShader;
	public Shader SelectedShader => _selectedShader;
    public Renderer ObjectRenderer => _renderer;

    public void ProduceUnit()
	{
		Instantiate(_unitPrefab, new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)), Quaternion.identity, _unitsParent);
	}

    public void SetOutlineShader()
    {
		_renderer.material.shader = _selectedShader;
	}

	public void SetBaseShader()
    {
		_renderer.material.shader = _baseShader;
	}
}