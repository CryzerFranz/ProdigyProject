using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menue_Buttons : MonoBehaviour
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

    #region Settings
    public void Settings()
    {
        setActiveCanvas(Canvas_Manager.instance.Canvas_Settings);
    }

    public void KeyBoardSettings()
    {
        setActiveCanvas(Canvas_Manager.instance.Canvas_KeyBoard_Settings);

    }
    #endregion
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


    private void setActiveCanvas(GameObject canvas)
    {
        Canvas_Manager.instance.activeCanvas.SetActive(false);
        Canvas_Manager.instance.activeCanvas = canvas;
        canvas.SetActive(true);
    }

    // type == false means -> CanvasToReturn = pauseMenue;
    // type == true means -> Canvas goes back to settings menue;
    public void returnButton(bool type)
    {
        if(!type)
        {
            Canvas_Manager.instance.activeCanvas.SetActive(false);
            Canvas_Manager.instance.activeCanvas = Canvas_Manager.instance.CanvasToReturn;
            Canvas_Manager.instance.activeCanvas.SetActive(true);
        }
        else
        {
            Canvas_Manager.instance.activeCanvas.SetActive(false);
            Canvas_Manager.instance.activeCanvas = Canvas_Manager.instance.Canvas_Settings;
            Canvas_Manager.instance.activeCanvas.SetActive(true);
        }
        
    }
}
