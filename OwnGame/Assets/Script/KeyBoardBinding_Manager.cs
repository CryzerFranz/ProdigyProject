using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This class is used to change the text from the UI.
/// </summary>
/// <param name="keybindingAction"> Shows you for which key this text ist binded </param>
/// <param name="setting_UI_Text"> The text object to change the text in the settings menue </param>
/// <param name="Task_UI_Text"> The text object to change the text in the task UI </param>
/// <param name="Task_UI_exists"> If true, the text in the UI will be changed if not true it's mean no task UI avaible for this keybindingAction </param>

public class KeyBoardBinding_Manager : MonoBehaviour
{
    //public static KeyBoardBinding_Manager instance;
    //void Awake()
    //{
    //    instance = this;
    //}

    //[SerializeField]
    //public TextMeshProUGUI AB_01_SettingMenue;
    //public TextMeshProUGUI AB_01_TaskMenue;
    //[SerializeField]
    //public TextMeshProUGUI AB_02_SettingMenue;
    //public TextMeshProUGUI AB_02_TaskMenue;
    //[SerializeField]
    //public TextMeshProUGUI AB_03_SettingMenue;
    //public TextMeshProUGUI AB_03_TaskMenue;
    //[SerializeField]
    //public TextMeshProUGUI AB_04_SettingMenue;
    //public TextMeshProUGUI AB_04_TaskMenue;
    //[SerializeField]
    //public TextMeshProUGUI AB_05_SettingMenue;
    //public TextMeshProUGUI AB_05_TaskMenue;
    //[SerializeField]
    //public TextMeshProUGUI AB_06_SettingMenue;
    //public TextMeshProUGUI AB_06_TaskMenue;
    //[SerializeField]
    //public TextMeshProUGUI AB_07_SettingMenue;
    //public TextMeshProUGUI AB_07_TaskMenue;

    //[System.Serializable]
    //public class KeyboardBindingText
    //{
    //    public KeyboardBindingText() { }
    //    public KeyboardBindingText(KeybindingActions action, TextMeshProUGUI settingMenue, TextMeshProUGUI taskUI = null, bool exists = false) 
    //    {
    //        this.keybindingAction = action;
    //        this.setting_UI_Text = settingMenue;
    //        this.Task_UI_Text = taskUI;
    //        this.Task_UI_exists = exists;
    //    }

    //    public KeybindingActions keybindingAction;
    //    public TextMeshProUGUI setting_UI_Text;
    //    public TextMeshProUGUI Task_UI_Text;
    //    public bool Task_UI_exists;
    //}

    //public KeyboardBindingText[] keyboardBindingText;
       
    //private void Start()
    //{
    //    keyboardBindingText[0] = new KeyboardBindingText(KeybindingActions.ability_01, KeyBoardBinding_Manager.instance.AB_01_SettingMenue, KeyBoardBinding_Manager.instance.AB_01_TaskMenue, true);
    //    keyboardBindingText[1] = new KeyboardBindingText(KeybindingActions.ability_02, KeyBoardBinding_Manager.instance.AB_02_SettingMenue, KeyBoardBinding_Manager.instance.AB_02_TaskMenue, true);
    //    keyboardBindingText[2] = new KeyboardBindingText(KeybindingActions.ability_03, KeyBoardBinding_Manager.instance.AB_03_SettingMenue, KeyBoardBinding_Manager.instance.AB_03_TaskMenue, true);
    //    keyboardBindingText[3] = new KeyboardBindingText(KeybindingActions.ability_04, KeyBoardBinding_Manager.instance.AB_04_SettingMenue, KeyBoardBinding_Manager.instance.AB_04_TaskMenue, true);
    //    keyboardBindingText[4] = new KeyboardBindingText(KeybindingActions.ability_05, KeyBoardBinding_Manager.instance.AB_05_SettingMenue, KeyBoardBinding_Manager.instance.AB_05_TaskMenue, true);
    //    keyboardBindingText[5] = new KeyboardBindingText(KeybindingActions.ability_06, KeyBoardBinding_Manager.instance.AB_06_SettingMenue, KeyBoardBinding_Manager.instance.AB_06_TaskMenue, true);
    //    keyboardBindingText[6] = new KeyboardBindingText(KeybindingActions.ability_07, KeyBoardBinding_Manager.instance.AB_07_SettingMenue, KeyBoardBinding_Manager.instance.AB_07_TaskMenue, true);


        
    //}
}
