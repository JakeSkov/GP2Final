using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScriptVehicleUIController : MonoBehaviour 
{
    public ScriptVehicleMove moveStats = new ScriptVehicleMove();
    public ScriptVehicleStats vehicleStats = new ScriptVehicleStats();

    public Text curSpeedText;
    public Text burnoutText;

    private string burnPercent;

	// Use this for initialization
	void Start () 
    {
        burnoutText.text = "Nope";
	}
	
	// Update is called once per frame
	void Update () 
    {
        burnPercent = (moveStats.burnTime / vehicleStats.currSpeed).ToString() + "%";
        UpdateUI();
	}

    void UpdateUI()
    {
        if ((moveStats.burnTime / vehicleStats.currSpeed) < 0)
        {
            burnPercent = "0";
        }
        burnoutText.text = string.Format("{0}%", burnPercent);
    }
}
