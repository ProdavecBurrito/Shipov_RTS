using UnityEngine;

public class SelectedShaderPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectedValue;

    private OutlineSelector[] _outlineSelectors;

    private void Start()
    {
        _selectedValue.OnSelected += OnSelected;
        OnSelected(_selectedValue.CurrentValue);
    }

    private void OnSelected(ISelectable selected)
    {
        if (selected != null)
        {
            if (_outlineSelectors != null)
            {
                foreach (var item in _outlineSelectors)
                {
                    item.SetBaseShader();
                }
            }
            _outlineSelectors = (selected as Component).GetComponentsInParent<OutlineSelector>();
            foreach (var item in _outlineSelectors)
            {
                item.SetOutlineShader();
            }
        }
        else
        {
            if(_outlineSelectors != null)
            {
                foreach (var item in _outlineSelectors)
                {
                    item.SetBaseShader();
                }
            }
             
        }
    }
}
