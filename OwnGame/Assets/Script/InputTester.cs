using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTester : MonoBehaviour
{
    public IEnumerator logicInput()
    {
        Debug.Log("Starting...");
        yield return StartCoroutine(WaitForKeyDown());
    }

    IEnumerator WaitForKeyDown()
    {
        bool pressed = false;
        Event e;
        while (!pressed)
        {
            e = Event.current;
            if (e.isKey)
            {
                pressed = true;
                InputManager.instance.changeKeyValue = e.keyCode;

            }

            yield return null; //you might want to only do this check once per frame -> yield return new WaitForEndOfFrame();
        }
    }
}
