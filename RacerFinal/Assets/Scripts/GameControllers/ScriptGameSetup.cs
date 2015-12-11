using UnityEngine;
using System.Collections;

public class ScriptGameSetup : MonoBehaviour 
{
    public ScriptVehicleMove[] vehicles = new ScriptVehicleMove[3];

    public Transform spawnPointLeft, spawnPointMiddle, spawnPointRight;

    void Start()
    {
        StartSetup();
    }

    void StartSetup()
    {
        for (int i = 0; i < vehicles.Length; i++)
        {
            switch (vehicles[i].startingLane)
            {
                case Lane.LEFT:
                    Instantiate(vehicles[i].gameObject, spawnPointLeft.transform.position, Quaternion.identity);
                    break;
                case Lane.MIDDLE:
                    Instantiate(vehicles[i].gameObject, spawnPointMiddle.transform.position, Quaternion.identity);
                    break;
                case Lane.RIGHT:
                    Instantiate(vehicles[i].gameObject, spawnPointRight.transform.position, Quaternion.identity);
                    break;
            }
        }
    }
}
