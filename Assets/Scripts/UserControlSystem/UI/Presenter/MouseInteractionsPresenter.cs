using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;
using Zenject;

public class MouseInteractionsPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private EventSystem _eventSystem;

    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackValue _attackTargetRMB;
    [SerializeField] private Transform _groundTransform;

    private Plane _groundPlane;

    [Inject]
    private void InjectInput()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);

        var inputStream = Observable.EveryUpdate().Where(_ => !_eventSystem.IsPointerOverGameObject());

        var leftMouseButton = inputStream.Where(_ => Input.GetMouseButtonDown(0));
        var rightMouseButton = inputStream.Where(_ => Input.GetMouseButtonDown(1));

        var lmbHitRay = leftMouseButton.Select(_ => _camera.ScreenPointToRay(Input.mousePosition));
        var rmbHitRay = rightMouseButton.Select(_ => _camera.ScreenPointToRay(Input.mousePosition));

        var lmbReycast = lmbHitRay.Select(ray => Physics.RaycastAll(ray));
        var rmbReycast = rmbHitRay.Select(ray => Physics.RaycastAll(ray));

        lmbReycast.Subscribe(rayHit =>
        {
            if (IsHit<ISelectable>(rayHit, out var selectable))
            {
                _selectedObject.SetValue(selectable);
            }
        });

        rmbReycast.Subscribe(rayHit =>
        {
            if (IsHit<IAttackable>(rayHit, out var attackable))
            {
                _attackTargetRMB.SetValue(attackable);
            }

            //if (_groundPlane.Raycast(rmbHitRay, out var place))
            //{
            //    _groundClicksRMB.SetValue(rmbHitRay.origin + rmbHitRay.direction, place);
            //}
        });
    }

    private bool IsHit<T>(RaycastHit[] hits, out T result) where T : class
    {
        result = default;
        if (hits.Length == 0)
        {
            return false;
        }
        result = hits.Select(hit => hit.collider.GetComponentInParent<T>()).Where(c => c != null).FirstOrDefault();
        return result != default;
    }
}
