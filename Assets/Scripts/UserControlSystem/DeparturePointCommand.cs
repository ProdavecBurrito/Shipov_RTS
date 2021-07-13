using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeparturePointCommand : IDeparturePoint
{
    public Vector3 Point { get; private set; }

    public DeparturePointCommand(Vector3 point)
    {
        Point = point;
    }
}
