using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepartureCommandCreator : CancellableCommandCreatorBase<IDeparturePoint, Vector3>
{
    protected override IDeparturePoint CreateCommand(Vector3 argument)
    {
        return new DeparturePointCommand(argument);
    }
}
