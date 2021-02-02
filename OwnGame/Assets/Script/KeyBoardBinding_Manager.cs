using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel.Design;
using System.Linq;

public class KeyBoardBinding_Manager : MonoBehaviour
{
    public static KeyBoardBinding_Manager instance;

    [SerializeField]
    private Keybindings keybindings;
  
    [SerializeField]
    public TextMeshProUGUI AB_01_SettingMenue;
    public TextMeshProUGUI AB_01_TaskMenue;
    [SerializeField]
    public TextMeshProUGUI AB_02_SettingMenue;
    public TextMeshProUGUI AB_02_TaskMenue;
    [SerializeField]
    public TextMeshProUGUI AB_03_SettingMenue;
    public TextMeshProUGUI AB_03_TaskMenue;
    [SerializeField]
    public TextMeshProUGUI AB_04_SettingMenue;
    public TextMeshProUGUI AB_04_TaskMenue;
    [SerializeField]
    public TextMeshProUGUI AB_05_SettingMenue;
    public TextMeshProUGUI AB_05_TaskMenue;
    [SerializeField]
    public TextMeshProUGUI AB_06_SettingMenue;
    public TextMeshProUGUI AB_06_TaskMenue;
    [SerializeField]
    public TextMeshProUGUI AB_07_SettingMenue;
    public TextMeshProUGUI AB_07_TaskMenue;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AB_01_SettingMenue.text = keybindings.keybindingChecks[8].keyCode.ToString();
        AB_01_TaskMenue.text = keybindings.keybindingChecks[8].keyCode.ToString();


        AB_02_SettingMenue.text = keybindings.keybindingChecks[9].keyCode.ToString();
        AB_02_TaskMenue.text = keybindings.keybindingChecks[9].keyCode.ToString();

        AB_03_SettingMenue.text = keybindings.keybindingChecks[10].keyCode.ToString();
        AB_03_TaskMenue.text = keybindings.keybindingChecks[10].keyCode.ToString();

        AB_04_SettingMenue.text = keybindings.keybindingChecks[11].keyCode.ToString();
        AB_04_TaskMenue.text = keybindings.keybindingChecks[11].keyCode.ToString();

        AB_05_SettingMenue.text = keybindings.keybindingChecks[12].keyCode.ToString();
        AB_05_TaskMenue.text = keybindings.keybindingChecks[12].keyCode.ToString();

        AB_06_SettingMenue.text = keybindings.keybindingChecks[13].keyCode.ToString();
        AB_06_TaskMenue.text = keybindings.keybindingChecks[13].keyCode.ToString();

        AB_07_SettingMenue.text = keybindings.keybindingChecks[14].keyCode.ToString();
        AB_07_TaskMenue.text = keybindings.keybindingChecks[14].keyCode.ToString();
    }
}
