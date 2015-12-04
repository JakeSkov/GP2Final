using UnityEngine;
using System.Collections;

public class ScriptTrackController : MonoBehaviour 
{
    public int numLaps;
    public string trackTitle = "Default";

    public const int MAX_LAPS = 20;
    public const int MIN_LAPS = 1;

    public void TestLaps()
    {
        if (numLaps > MAX_LAPS)
        {
            numLaps = MAX_LAPS;
        }
        if (numLaps < MIN_LAPS)
        {
            numLaps = MIN_LAPS;
        }
    }
}
