using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Keybindings", menuName = "Keybindings")]
public class Keybindings : ScriptableObject
{
    [System.Serializable]
    public class KeybindingCheck
    {
        public KeybindingActions keybindingAction;
        public KeyCode keyCode;
    }

    public KeybindingCheck[] keybindingChecks;
}
