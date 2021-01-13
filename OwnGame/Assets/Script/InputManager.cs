using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    private KeyCode changeKeyValue;

    [SerializeField]
    private Keybindings keybindings;
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
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log(keybindings.keybindingChecks[0].keyCode);
        }
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

    private IEnumerator StartCour()
    {
        Event e = Event.current;
        while(!e.isKey)
        {
            yield return null;
            Debug.Log("Kein Key");
        }
        changeKeyValue = e.keyCode;
    }

    public void ChangeAbility_01()
    {
        StartCour();
        keybindings.keybindingChecks[0].keyCode = changeKeyValue;
    }
    public void ChangeAbility_02()
    {

    }
    public void ChangeAbility_03()
    {

    }
    public void ChangeAbility_04()
    {

    }
    public void ChangeAbility_05()
    {

    }
    public void ChangeAbility_06()
    {

    }
    public void ChangeAbility_07()
    {

    }
}
