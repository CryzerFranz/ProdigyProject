using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedGame : MonoBehaviour
{
    public static bool GameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        
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
