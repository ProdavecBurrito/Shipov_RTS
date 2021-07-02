using System;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovementStop : MonoBehaviour, IAwaitable<AsyncExtensions.Void>
{
    public event Action OnStop;
    [SerializeField] private NavMeshAgent _agent;
    public IAwaiter<AsyncExtensions.Void> GetAwaiter() => new StopAwaiter(this);

    void Update()
    {
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    OnStop?.Invoke();
                }
            }
        }
    }

    public class StopAwaiter : BaseAwaiter<AsyncExtensions.Void>
    {
        private readonly UnitMovementStop _unitMovementStop;

        public StopAwaiter(UnitMovementStop unitMovementStop)
        {
            _unitMovementStop = unitMovementStop;
            _unitMovementStop.OnStop += OnStop;
        }

        public void OnStop()
        {
            _unitMovementStop.OnStop -= OnStop;
            OnResultValue(new AsyncExtensions.Void());
        }
    }
}
