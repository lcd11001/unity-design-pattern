using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] Slider healthBar;

    private void Start()
    {
        health.onHealthChangedAction += UpdateHealthBarUI;
    }

    private void OnDestroy()
    {
        health.onHealthChangedAction -= UpdateHealthBarUI;
    }

    private void UpdateHealthBarUI(float currentHealth, float fullHealth)
    {
        healthBar.value = currentHealth / fullHealth;
    }
}
