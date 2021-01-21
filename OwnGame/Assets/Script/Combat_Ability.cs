using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Ability : MonoBehaviour
{

    private InputManager inputManager;
    
    void Start()
    {
       inputManager = InputManager.instance ;
    }

    void Update()
    {
        if(inputManager.GetKeyDown(KeybindingActions.ability_01))
        {
            Debug.Log("Ability one");
        }
        if (inputManager.GetKeyDown(KeybindingActions.ability_02))
        {
            Debug.Log("Ability 2");
        }
    }
}
