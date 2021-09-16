using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionManager : MonoBehaviour
{
    Input _input;

    private void Awake()
    {
        _input = new Input();
    }

    private void OnEnable()
    {
        _input;
    }
}
