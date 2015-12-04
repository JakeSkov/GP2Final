using UnityEngine;
using System.Collections;

public enum VehicleTypes
{ 
    CAR,
    HATCHBACK,
    TRUCK
}

public class ScriptVehicleStats : MonoBehaviour 
{
    //Speed Variables
    [HideInInspector]
    public float maxSpeed;
    [HideInInspector]
    public float minSpeed;
    [HideInInspector]
    public float currSpeed;

    [HideInInspector]
    public float burnout;

    //Speed modifiers
    [HideInInspector]
    public float accel;
    [HideInInspector]
    public float brake;

    public VehicleTypes vehicleType;

    public void SetupVehicle()
    {
        switch (vehicleType)
        { 
            case VehicleTypes.CAR:
                maxSpeed = 1f;
                minSpeed = 0f;
                accel = 0.1f;
                brake = 0.2f;
                burnout = 1.0f;
                break;
            case VehicleTypes.HATCHBACK:
                maxSpeed = 1.25f;
                minSpeed = 0f;
                accel = 0.2f;
                brake = 0.3f;
                burnout = .75f;
                break;
            case VehicleTypes.TRUCK:
                maxSpeed = .75f;
                minSpeed = 0f;
                accel = 0.1f;
                brake = 0.3f;
                burnout = 1.5f;
                break;
        }
    }
}
