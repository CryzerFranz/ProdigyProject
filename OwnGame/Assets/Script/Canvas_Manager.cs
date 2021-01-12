using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Manager : MonoBehaviour
{

    public static Canvas_Manager instance;
    void Awake()
    {
        instance = this;
    }

    public GameObject Canvas;
    public GameObject Canvas_Pause_Menue;
    public GameObject Canvas_Settings;
    public GameObject Canvas_Player_UI;
    public GameObject Canvas_KeyBoard_Settings;
    public GameObject Canvas_FrameRate;
    public GameObject Canvas_Dead_Transition;

    [NonSerialized]
    public GameObject activeCanvas = null;
    [NonSerialized]
    public GameObject CanvasToReturn = null;

    private void Start()
    {
        Canvas_Pause_Menue.SetActive(false);
        Canvas_Settings.SetActive(false);
        Canvas_Player_UI.SetActive(true);
        Canvas_KeyBoard_Settings.SetActive(false);
        Canvas_FrameRate.SetActive(true);
        Canvas_Dead_Transition.SetActive(false);

        CanvasToReturn = Canvas_Pause_Menue;
    }


}
