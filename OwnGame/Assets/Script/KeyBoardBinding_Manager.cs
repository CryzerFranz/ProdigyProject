using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class KeyBoardBinding_Manager : MonoBehaviour
{
    public static KeyBoardBinding_Manager instance;
    void Awake()
    {
        instance = this;
    }

    public TextMeshProUGUI ability_01_Setting_txt;
    public TextMeshProUGUI ability_01_UI_txt;

    public TextMeshProUGUI ability_02_Setting_txt;
    public TextMeshProUGUI ability_02_UI_txt;

    public TextMeshProUGUI ability_03_Setting_txt;
    public TextMeshProUGUI ability_03_UI_txt;

}
