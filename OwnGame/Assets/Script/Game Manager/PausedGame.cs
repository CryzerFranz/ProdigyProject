using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedGame : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenueCanvas;
    // Update is called once per frame

    void Start()
    {
        PauseMenueCanvas.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
                PauseMenueCanvas.SetActive(false);
            }
            else
            {
                Pause();
                PauseMenueCanvas.SetActive(true);
                Canvas_Manager.instance.activeCanvas = Canvas_Manager.instance.Canvas_Pause_Menue;
                PlayerManager.instance.userInterface.SetActive(false);
            }
        }
    }

    public static void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        PlayerManager.instance.userInterface.SetActive(true);
    }

    public static void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
