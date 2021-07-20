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

    private IRMBMovable _rMBMovable;
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
        var rmbReycast = rmbHitRay.Select(ray => (ray, Physics.RaycastAll(ray)));


        lmbReycast.Subscribe(rayHit =>
        {
            if (IsHit<ISelectable>(rayHit, out var selectable))
            {
                _selectedObject.SetValue(selectable);
            }
            if (IsHit<IRMBMovable>(rayHit, out var sel))
            {
                Debug.Log("1");
                _rMBMovable = sel;
            }
        });

        rmbReycast.Subscribe(data =>
        {
            var (ray, hits) = data;

            if (IsHit<IAttackable>(hits, out var attackable))
            {
                _attackTargetRMB.SetValue(attackable);
            }
            else if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
                if (_rMBMovable != null)
                {
                    Debug.Log("2");
                    _rMBMovable.MoveTo(_groundClicksRMB.CurrentValue);
                }
            }
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
