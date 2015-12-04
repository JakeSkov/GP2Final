using UnityEngine;
using System.Collections;

public class ScriptVehicleController : MonoBehaviour 
{
    //Gathers the stat varables from the stats script
    public ScriptVehicleStats stats; 

	void Awake() 
    {
        stats.SetupVehicle();
	}
	
	// Update is called once per frame
	void Update () 
    {
        ModifySpeed();
	}

    void ModifySpeed()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetAxis("Vertical") > 0 && stats.currSpeed < stats.minSpeed)
            {
                stats.currSpeed -= Input.GetAxis("Vertical") * (stats.currSpeed * (stats.accel * Time.deltaTime));
            }
            if (Input.GetAxis("Vertical") < 0 && stats.currSpeed >= stats.maxSpeed)
            {
                stats.currSpeed += Input.GetAxis("Vertical") * (stats.currSpeed * (stats.brake * Time.deltaTime));
            }
            Debug.Log("Called");
        }
    }
}
