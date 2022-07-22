using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float keyboardSensitivity;
    private IInputController inputController;

    private Transform parent;

    private void Start()
    {
        parent = transform.parent;
        inputController = parent.gameObject.GetComponent<IInputController>();

        // Fixed: move mouse quickly, can make character move
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Rotate();
    }
    private void Rotate()
    {
        float keyX = inputController.GetAxisInput("Horizontal");
        keyX *= keyboardSensitivity;

        float mouseX = inputController.GetAxisInput("Mouse X");
        mouseX *= mouseSensitivity;

        if (mouseX != 0)
        {
            parent.Rotate(Vector3.up, mouseX * Time.deltaTime);
        }
        else if (keyX != 0)
        {
            parent.Rotate(Vector3.up, keyX * Time.deltaTime);
        }
    }
}
