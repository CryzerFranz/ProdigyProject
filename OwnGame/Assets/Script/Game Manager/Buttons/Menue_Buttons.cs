using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menue_Buttons : MonoBehaviour
{
    [SerializeField]
    private Canvas_Manager UI;

    public static bool GameIsPaused = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                UI.Canvas_Pause_Menue.SetActive(false);
            }
            else
            {
                Pause();
                UI.Canvas_Pause_Menue.SetActive(true);
                UI.activeCanvas = UI.Canvas_Pause_Menue;
                UI.Canvas_Player_UI.SetActive(false);
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        UI.Canvas_Player_UI.SetActive(true);
        UI.Canvas_Pause_Menue.SetActive(false);

    }

    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

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
        setActiveCanvas(UI.Canvas_Settings);
    }

    public void KeyBoardSettings()
    {
        setActiveCanvas(UI.Canvas_KeyBoard_Settings);

    }
    #endregion
  
    public void Save()
    {
        Debug.Log("No implementation at the momemnt");
    }

    private void setActiveCanvas(GameObject canvas)
    {
        UI.activeCanvas.SetActive(false);
        UI.activeCanvas = canvas;
        canvas.SetActive(true);
    }

    // type == false means -> CanvasToReturn = pauseMenue;
    // type == true means -> Canvas goes back to settings menue;
    public void returnButton(bool type)
    {
        if(!type)
        {
            UI.activeCanvas.SetActive(false);
            UI.activeCanvas = UI.CanvasToReturn;
            UI.activeCanvas.SetActive(true);
        }
        else
        {
            UI.activeCanvas.SetActive(false);
            UI.activeCanvas = UI.Canvas_Settings;
            UI.activeCanvas.SetActive(true);
        }
        
    }
}
