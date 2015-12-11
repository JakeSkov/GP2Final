using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class ScriptProfileUIController : MonoBehaviour 
{
    //Ints
    public int playerXP = 0;
    public int XPtoUpgrade = 150;

    //Bools
    [HideInInspector]
    public bool useCoupe, useHatchback, useTruck;
    [HideInInspector]
    public bool tunedEngine, turboCharged, raceTyre;

    //Buttons
    public Button CoupeButton, HatchbackButton, TruckButton;
    public Button TuneEngineButton, TyreButton, TurboButton;

    //Text
    public Text topSpeedtext, accelerateText, brakeText, burnText;
    public Text XpToUpgradeEngineText, XpToUpgradeTyreText, XpToUpgradeTurboText;
    public Text playerNameText;

    //Scripts
    public ScriptVehicleStats stats;

    //Enums
    public VehicleTypes type;

    void Awake()
    {
        useCoupe = true;
    }

	// Update is called once per frame
	void Update () 
    {
        if (useCoupe)
        {
            CoupeButton.interactable = false;
            HatchbackButton.interactable = true;
            TruckButton.interactable = true;
        }
        else if (useHatchback)
        {
            CoupeButton.interactable = true;
            HatchbackButton.interactable = false;
            TruckButton.interactable = true;
        }
        else if (useTruck)
        {
            CoupeButton.interactable = true;
            HatchbackButton.interactable = true;
            TruckButton.interactable = false;
        }

        UpdateUI();
	}

    void UpdateUI()
    {
        stats.SetupVehicle();

        topSpeedtext.text = "Top Speed:\t\t\t" + (stats.maxSpeed - 0.1f).ToString();
        accelerateText.text = "Acceleration:\t\t" + stats.accel.ToString();
        brakeText.text = "Braking:\t\t\t\t" + stats.brake.ToString();
        burnText.text = "Burnout:\t\t\t\t" + stats.burnout.ToString();

        if (playerXP < XPtoUpgrade)
        {
            XpToUpgradeEngineText.color = Color.red;
            XpToUpgradeTurboText.color = Color.red;
            XpToUpgradeTyreText.color = Color.red;

            TuneEngineButton.interactable = false;
            TyreButton.interactable = false;
            TurboButton.interactable = false;
        }
        else 
        {
            XpToUpgradeEngineText.color = Color.white;
            XpToUpgradeTurboText.color = Color.white;
            XpToUpgradeTyreText.color = Color.white;

            TuneEngineButton.interactable = true;
            TyreButton.interactable = true;
            TurboButton.interactable = true;
        }

    }

    public void CoupeOnClick()
    {
        useCoupe = true;

        if (useHatchback || useTruck)
        {
            useTruck = false;
            useHatchback = false;
        }

        type = VehicleTypes.CAR;
    }

    public void HatchbackOnClick()
    {
        useHatchback = true;

        if (useCoupe || useTruck)
        {
            useTruck = false;
            useCoupe = false;
        }

        type = VehicleTypes.HATCHBACK;
    }

    public void TruckOnClick()
    {
        useTruck = true;

        if (useHatchback || useCoupe)
        {
            useCoupe = false;
            useHatchback = false;
        }

        type = VehicleTypes.TRUCK;
    }

    public void SaveOnClick()
    {
        //StreamWriter sw = new StreamWriter(Application.dataPath + "/Profile/Profile_Data.txt");
        //sw.WriteLine(playerNameText.text.ToString());
        //sw.WriteLine(type.ToString());

        //if(tunedEngine)
        //{
        //    sw.Write("Tuned_");
        //}
        //if(turboCharged)
        //{
        //    sw.Write("Turbo_");
        //}
        //if (raceTyre)
        //{
        //    sw.Write("Tyre_");
        //}

        Application.LoadLevel("MenuMain");
    }
}
