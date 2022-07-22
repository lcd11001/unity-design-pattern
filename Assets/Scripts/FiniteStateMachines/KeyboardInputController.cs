using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputController : MonoBehaviour, IInputController
{
    public float GetAxisInput(string axisName)
    {
        return Input.GetAxis(axisName);
    }

    public bool GetKeyDownInput(KeyCode keyCode)
    {
        return Input.GetKeyDown(keyCode);
    }

    public bool GetKeyInput(KeyCode keyCode)
    {
        return Input.GetKey(keyCode);
    }
}
