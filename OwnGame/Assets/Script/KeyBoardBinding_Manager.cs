using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel.Design;
using System.Linq;
using System;

public class KeyBoardBinding_Manager : MonoBehaviour
{
    public static KeyBoardBinding_Manager instance;

    public enum indexThirdPersonKeyBinding : int
    {
        Ability_01_I = 0,
        Ability_02_I = 1,
        Ability_03_I = 2,
        Ability_04_I = 3,
        Ability_05_I = 4,
        Ability_06_I = 5,
        Ability_07_I = 6,
    }

    //public enum indexFirstPersonKeyBinding : int
    //{
    //    todo
    //}

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
        //Keybinding_ThirdPerson
        
        AB_01_SettingMenue.text = getNicerString(keybindings.keybindingChecks[(int)indexThirdPersonKeyBinding.Ability_01_I].keyCode.ToString());
        AB_01_TaskMenue.text = getNicerString(keybindings.keybindingChecks[(int)indexThirdPersonKeyBinding.Ability_01_I].keyCode.ToString());

        AB_02_SettingMenue.text = getNicerString(keybindings.keybindingChecks[(int)indexThirdPersonKeyBinding.Ability_02_I].keyCode.ToString());
        AB_02_TaskMenue.text = getNicerString(keybindings.keybindingChecks[(int)indexThirdPersonKeyBinding.Ability_02_I].keyCode.ToString());

        AB_03_SettingMenue.text = getNicerString(keybindings.keybindingChecks[(int)indexThirdPersonKeyBinding.Ability_03_I].keyCode.ToString());
        AB_03_TaskMenue.text = getNicerString(keybindings.keybindingChecks[(int)indexThirdPersonKeyBinding.Ability_03_I].keyCode.ToString());

        AB_04_SettingMenue.text = getNicerString(keybindings.keybindingChecks[(int)indexThirdPersonKeyBinding.Ability_04_I].keyCode.ToString());
        AB_04_TaskMenue.text = getNicerString(keybindings.keybindingChecks[(int)indexThirdPersonKeyBinding.Ability_04_I].keyCode.ToString());

        AB_05_SettingMenue.text = getNicerString(keybindings.keybindingChecks[(int)indexThirdPersonKeyBinding.Ability_05_I].keyCode.ToString());
        AB_05_TaskMenue.text = getNicerString(keybindings.keybindingChecks[(int)indexThirdPersonKeyBinding.Ability_05_I].keyCode.ToString());

        AB_06_SettingMenue.text = getNicerString(keybindings.keybindingChecks[(int)indexThirdPersonKeyBinding.Ability_06_I].keyCode.ToString());
        AB_06_TaskMenue.text = getNicerString(keybindings.keybindingChecks[(int)indexThirdPersonKeyBinding.Ability_06_I].keyCode.ToString());

        AB_07_SettingMenue.text = getNicerString(keybindings.keybindingChecks[(int)indexThirdPersonKeyBinding.Ability_07_I].keyCode.ToString());
        AB_07_TaskMenue.text = getNicerString(keybindings.keybindingChecks[(int)indexThirdPersonKeyBinding.Ability_07_I].keyCode.ToString());

        //Keybinding_FirstPerson

    }

    private string getNicerString(string value)
    {
        if(value.StartsWith("Alpha"))
        {
            value = TrimStart(value, "Alpha");
        }
        if (value.StartsWith("KeyPad"))
        {
            value = TrimStart(value, "KeyPad");
        }
        return value;
    }
    private string TrimStart(string target, string trimString)
    {
        if (trimString.Length == 0) return target;

        string result = target;
        if(result.StartsWith(trimString))
        {
            result = result.Substring(trimString.Length);
        }
        return result;

    }
}
