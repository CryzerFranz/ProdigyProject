using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedGame : MonoBehaviour
{
    [SerializeField]
    private Canvas_Manager UI;

    public static bool GameIsPaused = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
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
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
