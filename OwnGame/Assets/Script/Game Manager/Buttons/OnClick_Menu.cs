using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick_Menu : MonoBehaviour
{
    public void Menu()
    {
        Debug.Log("No menu at the moment!");
        //TODO
        //no menu at the moment
    }

    public void Exit()
    {
        Debug.Log("Application has been quited");
        Application.Quit();
    }

    public void Settings()
    {
        Debug.Log("No settings menu at the moment!");
        //TODO
        //no settings menu at the moment
    }

    public void Resume()
    {
        GameObject canvas = GameObject.Find("Pause Menue");
        canvas.SetActive(false);
        PausedGame.Resume();
    }
}
