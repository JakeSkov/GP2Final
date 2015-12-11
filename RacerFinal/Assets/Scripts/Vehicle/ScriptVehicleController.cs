using UnityEngine;
using System.Collections;

public class ScriptVehicleController : MonoBehaviour 
{
    //Gathers the stat varables from the stats script
    public ScriptVehicleStats stats; 

	void Awake() 
    {
        //Sets up the vehicle
        stats.SetupVehicle();
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Changes Speed
        ModifySpeed();
	}

    void ModifySpeed()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            //Speed Up
            if (Input.GetAxis("Vertical") > 0 && stats.currSpeed >= stats.minSpeed && stats.currSpeed < stats.maxSpeed - .1f)
            {
                stats.currSpeed += Input.GetAxis("Vertical") * ((stats.accel * Time.deltaTime) / stats.accel);
            }
            //Slow Down
            if (Input.GetAxis("Vertical") < 0 && stats.currSpeed < stats.maxSpeed && stats.currSpeed >= stats.minSpeed + .1f)
            {
                stats.currSpeed += Input.GetAxis("Vertical") * ((stats.brake * Time.deltaTime) / stats.brake);
            }
        }
    }
}
