using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// @Author Jake Skov
/// </summary>
public class ScriptVehicleUIController : MonoBehaviour 
{
    //Scripts
    public ScriptVehicleMove moveStats;
    public ScriptVehicleStats vehicleStats;

    //Text
    public Text curSpeedText;
    public Text burnoutText;

    //Ints
    private int burnPercent;

    //Bools
    public bool isDead;
	
	// Update is called once per frame
	void Update () 
    {
        //Calculates the percentage of burnout
        Debug.Log(moveStats.burnTime / vehicleStats.burnout);
        burnPercent = (int)((moveStats.burnTime / vehicleStats.burnout) * 10);
        UpdateUI();
	}

    void UpdateUI()
    {
        //Displays UI Elements
        burnoutText.text = burnPercent.ToString() + "%";
        curSpeedText.text = moveStats.stats.currSpeed.ToString();

        if (burnPercent >= 100)
        {
            moveStats.stats.currSpeed = 0;
            isDead = true;
        }
    }
}
