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
        GameObject canvas_settings = GameObject.Find("Settings");
        GameObject canvas_menue = GameObject.Find("Pause Menue");
        canvas_menue.SetActive(false);
        canvas_settings.SetActive(true);
    }

    public void Resume()
    {
        GameObject canvas = GameObject.Find("Pause Menue");
        canvas.SetActive(false);
        PausedGame.Resume();
    }

    public void Save()
    {
        Debug.Log("No implementation at the momemnt");
    }
}
