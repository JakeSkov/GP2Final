using UnityEngine;
using System.Collections;

public class ScriptVehicleMove : MonoBehaviour
{
    public ScriptSetup waypoints;
    public ScriptVehicleController carControl;
    public Lane startingLane;

    [HideInInspector]
    public float burnTime = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
    }

    void Move()
    {
        for (int i = 0; i < waypoints.waypoints.Length; i++ )
        {
            switch (waypoints.waypoints[i].moveType)
            { 
                case MovementTypes.BEZIER_CURVE:
                    InvokeRepeating("Burnout", 0, .1f);
                    break;
                case MovementTypes.STRAIGHT_LINE:
                    
                    break;
            }
        }
    }

    void Burnout()
    {
        float speedDif = carControl.stats.currSpeed - 0.7f;
        burnTime += (speedDif) / 10;

        if (burnTime > carControl.stats.burnout)
        {
            carControl.stats.currSpeed = 0;
        }
    }
}
