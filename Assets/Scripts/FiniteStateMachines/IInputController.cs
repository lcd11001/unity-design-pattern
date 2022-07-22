using UnityEngine;

public interface IInputController
{
    float GetAxisInput(string axisName);
    bool GetKeyInput(KeyCode keyCode);
    bool GetKeyDownInput(KeyCode keyCode);
}
