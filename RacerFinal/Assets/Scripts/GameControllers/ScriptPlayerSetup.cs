using UnityEngine;
using System.Collections;
using System.IO;

public class ScriptPlayerSetup : MonoBehaviour
{
    //GameObjects
    public GameObject playerVehicle;

    //Strings
    string playerName;
    string[] upgrades = new string[3];

    //Ints
    int playerXP;

    //Enums
    VehicleTypes vehicle;
    public Lane startLane;

    // Use this for initialization
    void Start()
    {

            startLane = Lane.MIDDLE;
            GetComponent<ScriptVehicleMove>().waypoints =
                GameObject.Find("MiddleLaneWaypoints").GetComponent<ScriptSetup>();

        transform.position = GetComponent<ScriptVehicleMove>().waypoints.waypoints[0].transform.position;
    }
}
