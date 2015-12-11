using UnityEngine;
using System.Collections;

public class ScriptAIBehaviour : MonoBehaviour 
{
    public Lane startLane;

    public GameObject aiVehicle;

	// Use this for initialization
	void Start () 
    {
	
	}

    void Setup()
    {
        if (startLane == Lane.LEFT)
        {
            Instantiate(aiVehicle,
                GameObject.Find("LeftLaneWaypoints").GetComponent<ScriptSetup>().waypoints[0].startPoint.transform.position,
                Quaternion.identity);
        }

        if (startLane == Lane.RIGHT)
        {
            Instantiate(aiVehicle,
                GameObject.Find("RightLaneWaypoints").GetComponent<ScriptSetup>().waypoints[0].startPoint.transform.position,
                Quaternion.identity);
        }
    }
}
