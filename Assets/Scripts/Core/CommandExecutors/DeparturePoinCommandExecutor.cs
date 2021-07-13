using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeparturePoinCommandExecutor : CommandExecutorBase<IDeparturePoint>
{
    [SerializeField] MainBuilding Building;

    public override void ExecuteSpecificCommand(IDeparturePoint command)
    {
        Building.SetDeparturePoint(command.Point);
    }
}
