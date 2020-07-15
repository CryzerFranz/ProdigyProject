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
            }
        }
    }

    public static void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public static void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
