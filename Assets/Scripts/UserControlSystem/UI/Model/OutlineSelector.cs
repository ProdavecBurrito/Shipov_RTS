using UnityEngine;

public class OutlineSelector : MonoBehaviour
{
	[SerializeField] private Shader _baseShader;
	[SerializeField] private Shader _selectedShader;
	[SerializeField] private Renderer[] _renderers;

	public void SetOutlineShader()
	{
		if (this == null)
		{
			return;
		}
		foreach (var item in _renderers)
        {
			item.material.shader = _selectedShader;
        }
	}

	public void SetBaseShader()
	{
		foreach (var item in _renderers)
		{
			item.material.shader = _baseShader;
		}
	}
}
