using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatSuper : MonoBehaviour
{
    static public PlayerCombatSuper instance;
    private void Awake()
    {
        instance = this;
    }

    public AbilityTImeBar abilityTimeBar;

    private PlayerCombat playerCombatInstance;
    private InputManager input;
    private AbilityProzentTimeBar abilitiesStartEndValue;


    // Start is called before the first frame update
    void Start()
    {
        abilitiesStartEndValue = abilityTimeBar.abilityKeyPosition;
        playerCombatInstance = PlayerCombat.instance;
        input = InputManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (input.GetKeyDown(KeybindingActions.ability_01) && playerCombatInstance.firstAnimationPressed == true)
        {
            if(abilityTimeBar.slider.normalizedValue >= abilitiesStartEndValue.Ability_01_TimeStart && abilityTimeBar.slider.normalizedValue <= abilitiesStartEndValue.Ability_01_TimeEnd)
            {
                Debug.Log("Super Animation!!!!");
            }
        }
    }
}
