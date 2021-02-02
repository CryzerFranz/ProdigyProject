using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedGame : MonoBehaviour
{
    public static bool GameIsPaused = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
                Canvas_Manager.instance.Canvas_Pause_Menue.SetActive(false);
            }
            else
            {
                Pause();
                Canvas_Manager.instance.Canvas_Pause_Menue.SetActive(true);
                Canvas_Manager.instance.activeCanvas = Canvas_Manager.instance.Canvas_Pause_Menue;
                Canvas_Manager.instance.Canvas_Player_UI.SetActive(false);
            }
        }
    }

    public static void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        Canvas_Manager.instance.Canvas_Player_UI.SetActive(true);
    }

    public static void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
