using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Manager : MonoBehaviour
{   
    //Prefabs müssen aktuell gehalten werden (Canvas Parent)
    public GameObject mainCanvas;
    [NonSerialized]
    public GameObject Canvas_Pause_Menue;
    [NonSerialized]
    public GameObject Canvas_Settings;
    [NonSerialized]
    public GameObject Canvas_Player_UI;
    [NonSerialized]
    public GameObject Canvas_KeyBoard_Settings;
    [NonSerialized]
    public GameObject Canvas_FrameRate;
    [NonSerialized]
    public GameObject Canvas_Dead_Transition;

    [NonSerialized]
    public GameObject activeCanvas = null;
    [NonSerialized]
    public GameObject CanvasToReturn = null;
    private void Start()
    {
        for (int i = 0; i < mainCanvas.transform.childCount; i++)
        {
            switch (mainCanvas.transform.GetChild(i).name)
            {
                case "PlayerUI":
                    Canvas_Player_UI = mainCanvas.transform.GetChild(i).gameObject;
                    Canvas_Player_UI.SetActive(true);
                    break;
                case "FrameRate_Canvas":
                    Canvas_FrameRate = mainCanvas.transform.GetChild(i).gameObject;
                    Canvas_FrameRate.SetActive(true);
                    break;
                case "Canvas_Dead_Transition":
                    Canvas_Dead_Transition = mainCanvas.transform.GetChild(i).gameObject;
                    Canvas_Dead_Transition.SetActive(false);
                    break;
                case "Pause_Menue":
                    Canvas_Pause_Menue = mainCanvas.transform.GetChild(i).gameObject;
                    Canvas_Pause_Menue.SetActive(false);
                    break;
                case "Settings":
                    Canvas_Settings = mainCanvas.transform.GetChild(i).gameObject;
                    Canvas_Settings.SetActive(false);
                    break;
                case "KeyBoard_Settings":
                    Canvas_KeyBoard_Settings = mainCanvas.transform.GetChild(i).gameObject;
                    Canvas_KeyBoard_Settings.SetActive(false);
                    break;
            }
        }
        CanvasToReturn = Canvas_Pause_Menue;
    }
}
