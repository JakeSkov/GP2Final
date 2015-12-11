using UnityEngine;
using System.Collections;

public class ScriptMenuOnClick : MonoBehaviour 
{
    public void SinglePlayerOnClick()
    {
        Application.LoadLevel("Test");
    }

    public void MultiplayerOnClick()
    {
        Application.LoadLevel("MenuMPLobby");
    }

    public void EditProfileOnClick()
    {
        Application.LoadLevel("MenuProfile");
    }

    public void CreditsOnClick()
    {
        Application.LoadLevel("MenuCredits");
    }

    public void QuitOnClick()
    {
        Application.Quit();
    }

    public void ReturnOnClick()
    {
        Application.LoadLevel("MenuMain");
    }
}
