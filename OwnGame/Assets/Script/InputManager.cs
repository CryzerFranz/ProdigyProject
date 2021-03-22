using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    Event e;
    public KeyCode changeKeyValue;
    bool waitingForKey;
    [SerializeField]
    private Keybindings keybindings;
    private KeyBoardBinding_Manager KBM_instance;
    //[SerializeField]
    //private KeyBoardBinding_Manager bindingtexts;

    public Keybindings keybindingDrone;
    public Keybindings keybindingThrid;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
        changeKeyValue = KeyCode.None;
        KBM_instance = KeyBoardBinding_Manager.instance;
    }

    public KeyCode GetKeyForAction(KeybindingActions keybindgingAction)
    {
        foreach(Keybindings.KeybindingCheck keybindingCheck in keybindings.keybindingChecks)
        {
            if(keybindingCheck.keybindingAction == keybindgingAction)
            {
                return keybindingCheck.keyCode;
            }
        }
        return KeyCode.None;
    }

    public bool GetKeyDown(KeybindingActions key)
    {
        foreach (Keybindings.KeybindingCheck keybindingCheck in keybindings.keybindingChecks)
        {
            if (keybindingCheck.keybindingAction == key)
            {
                return Input.GetKeyDown(keybindingCheck.keyCode);
            }
        }
        return false;
    }

    public bool GetKey(KeybindingActions key)
    {
        foreach (Keybindings.KeybindingCheck keybindingCheck in keybindings.keybindingChecks)
        {
            if (keybindingCheck.keybindingAction == key)
            {
                return Input.GetKey(keybindingCheck.keyCode);
            }
        }
        return false;
    }

    public bool GetKeyUp(KeybindingActions key)
    {
        foreach (Keybindings.KeybindingCheck keybindingCheck in keybindings.keybindingChecks)
        {
            if (keybindingCheck.keybindingAction == key)
            {
                return Input.GetKeyUp(keybindingCheck.keyCode);
            }
        }
        return false;
    }

    IEnumerator logicInput(KeybindingActions keyName, TextMeshProUGUI settingText, TextMeshProUGUI taskText)
    {
        Debug.Log("Starting...");
        yield return StartCoroutine(WaitForKeyDown(keyName, settingText, taskText));
    }

    private void OnGUI()
    {
        e = Event.current;

        if(e.isKey && waitingForKey)
        {
            changeKeyValue = e.keyCode;
            waitingForKey = false;
        }
    }

    IEnumerator WaitForKeyDown(KeybindingActions keyActionName, TextMeshProUGUI settingText, TextMeshProUGUI taskText)
    {
        while (waitingForKey)
        {
            yield return null;
        }

        foreach(Keybindings.KeybindingCheck element in keybindings.keybindingChecks)
        {
            if(element.keybindingAction == keyActionName)
            {
                element.keyCode = changeKeyValue;
                settingText.text = changeKeyValue.ToString();
                taskText.text = changeKeyValue.ToString();
                changeKeyValue = KeyCode.None;

                break;
            }
        }
    }

    public void ChangeAbility_01()
    {
        waitingForKey = true;
        StartCoroutine(logicInput(KeybindingActions.ability_01, KBM_instance.AB_01_SettingMenue, KBM_instance.AB_01_TaskMenue));
    }
    public void ChangeAbility_02()
    {
        waitingForKey = true;
        StartCoroutine(logicInput(KeybindingActions.ability_02, KBM_instance.AB_02_SettingMenue, KBM_instance.AB_02_TaskMenue));
    }
    public void ChangeAbility_03()
    {
        waitingForKey = true;
        StartCoroutine(logicInput(KeybindingActions.ability_03, KBM_instance.AB_03_SettingMenue, KBM_instance.AB_03_TaskMenue));
    }
    public void ChangeAbility_04()
    {
        waitingForKey = true;
        StartCoroutine(logicInput(KeybindingActions.ability_04, KBM_instance.AB_04_SettingMenue, KBM_instance.AB_04_TaskMenue));
    }
    public void ChangeAbility_05()
    {
        waitingForKey = true;
        StartCoroutine(logicInput(KeybindingActions.ability_05, KBM_instance.AB_05_SettingMenue, KBM_instance.AB_05_TaskMenue));
    }
    public void ChangeAbility_06()
    {
        waitingForKey = true;
        StartCoroutine(logicInput(KeybindingActions.ability_06, KBM_instance.AB_06_SettingMenue, KBM_instance.AB_06_TaskMenue));
    }
    public void ChangeAbility_07()
    {
        waitingForKey = true;
        StartCoroutine(logicInput(KeybindingActions.ability_07, KBM_instance.AB_07_SettingMenue, KBM_instance.AB_07_TaskMenue));
    }



    /////TEST//////
    public void ChangeToDrone()
    {
        keybindings = keybindingDrone;
    }
}
