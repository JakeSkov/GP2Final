using UnityEngine;
using System.Collections;

public enum MovementTypes
{ 
    STRAIGHT_LINE,
    BEZIER_CURVE
}

public enum Lane
{
    LEFT,
    MIDDLE,
    RIGHT
}

public class ScriptWaypoint : MonoBehaviour 
{
    public MovementTypes moveType;
    public Lane lane;
    public Transform startPoint, endPoint, curvePoint;
    public bool hasBurnout = false;
}
