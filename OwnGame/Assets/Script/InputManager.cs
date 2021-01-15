using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public TextMeshProUGUI testText;
    Event e;
    public InputTester test;
    public KeyCode changeKeyValue;
    bool waitingForKey;
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
        changeKeyValue = KeyCode.None;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log(keybindings.keybindingChecks[0].keybindingAction);
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


    IEnumerator logicInput()
    {
        Debug.Log("Starting...");
        yield return StartCoroutine(WaitForKeyDown());
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
    IEnumerator WaitForKeyDown()
    {
        bool pressed = false;
        while (!e.isKey)
        {
            // yield return null; //you might want to only do this check once per frame -> yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
        }
        pressed = true; testText.color = Color.green;
        changeKeyValue = e.keyCode;
    }

    public void ChangeAbility_01()
    {
        waitingForKey = true;
        Debug.Log("Button pressed");
        testText.color = Color.red;
        StartCoroutine(logicInput());
        ChangeAbility_02();
        keybindings.keybindingChecks[0].keyCode = changeKeyValue;
    }
    public void ChangeAbility_02()
    {
        Debug.Log("Fucked up");
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
