using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Keybindings", menuName = "Keybingings")]
public class Keybindings : ScriptableObject
{
    [System.Serializable]
    public class KeybindingCheck
    {
        public bool need_UI_Task;
        public KeybindingActions keybindingAction;
        public KeyCode keyCode;
        public TextMeshProUGUI UI_Setting;
        public TextMeshProUGUI UI_Task;
    }

    public KeybindingCheck[] keybindingChecks;
}
