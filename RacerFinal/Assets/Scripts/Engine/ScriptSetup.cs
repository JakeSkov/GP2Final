using UnityEngine;
using System.Collections;

public class ScriptSetup : MonoBehaviour 
{
    public ScriptWaypoint[] waypoints = new ScriptWaypoint[15];

    public void Start()
    {
        for (int i = 0; i < waypoints.Length; i++)
        {
            switch (waypoints[i].moveType)
            { 
                case MovementTypes.BEZIER_CURVE:
                    break;
                case MovementTypes.STRAIGHT_LINE:
                    break;
            }
        }
    }
}
