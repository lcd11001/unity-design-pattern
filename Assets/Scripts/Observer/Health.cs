using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float fullHealth = 100f;
    [SerializeField] float drainPerSecond = 2f;
    float currentHealth = 0;

    void Awake()
    {
        ResetHealth();
        StartCoroutine(SimulateHealthDrain());
    }

    private void OnEnable()
    {
        var level = GetComponent<Level>();
        if (level != null)
        {
            level.onLevelUpAction += OnLevelUpAction;
            level.onLevelUpCallback += OnLevelUpCallback;
        }
    }

    private void OnDisable()
    {
        var level = GetComponent<Level>();
        if (level != null)
        {
            level.onLevelUpAction -= OnLevelUpAction;
            level.onLevelUpCallback -= OnLevelUpCallback;
        }
    }

    private IEnumerator SimulateHealthDrain()
    {
        while (currentHealth > 0)
        {
            currentHealth -= drainPerSecond;
            yield return new WaitForSeconds(1);
        }
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public void ResetHealth()
    {
        currentHealth = fullHealth;
    }

    public void OnLevelUp(int newLevel)
    {
        // MUST choose from dynamic section in inspector
        // https://forum.unity.com/threads/invoking-unityevent-with-argument.282670/
        Debug.Log($"received NEW LEVEL {newLevel}");
        ResetHealth();
    }

    private void OnLevelUpAction(int newLevel)
    {
        Debug.Log($"received NEW LEVEL ACTION {newLevel}");
        ResetHealth();
    }

    private void OnLevelUpCallback(int newLevel)
    {
        Debug.Log($"received NEW LEVEL CALLBACK {newLevel}");
        ResetHealth();
    }
}
