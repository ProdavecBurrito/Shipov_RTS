using UnityEngine;

public class SelectedShaderPresenter : MonoBehaviour
{
    [SerializeField] private Shader _baseShader;
    [SerializeField] private Material _objectMaterial;
    [SerializeField] private SelectableValue _selectedValue;

    private void Start()
    {
        _selectedValue.OnSelected += OnSelected;
        OnSelected(_selectedValue.CurrentValue);
    }

    private void OnSelected(ISelectable selected)
    {
        if (selected != null)
        {
            _objectMaterial.shader = selected.SelectedShader;
        }
        else
        {
            _objectMaterial.shader = _baseShader;
        }
    }
}
