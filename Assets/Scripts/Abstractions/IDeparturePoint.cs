using UnityEngine;

public interface IDeparturePoint : ICommand
{
    public Vector3 Point { get; }
}
