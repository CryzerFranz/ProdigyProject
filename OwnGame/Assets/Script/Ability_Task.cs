using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ability_Task : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    TextMeshProUGUI ability_01_txt;

    int AbilityTask_Count = 7;

    public string ability_01_KeyCode;
    public string ability_02_KeyCode;
    public string ability_03_KeyCode;

    void Start()
    {
       
    }

    public void changeKeyCode_01()
    {
        ability_01_txt.text = Input.inputString;
    }
    

}
