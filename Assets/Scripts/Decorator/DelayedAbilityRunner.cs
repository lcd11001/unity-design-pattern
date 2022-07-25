using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DelayedAbilityRunner : MonoBehaviour
{
    [SerializeField] BaseContext delayContext;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            delayContext.ChangeAbility<DelayedFireBallAbility>();
        }
        else if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            delayContext.ChangeAbility<DelayedHealAbility>();
        }
        else if (Input.GetKeyUp(KeyCode.Keypad3))
        {
            delayContext.ChangeAbility<DelayedRageAbility>();
        }
    }

    public void OnFireBallClicked()
    {
        delayContext.ChangeAbility<DelayedFireBallAbility>();
    }

    public void OnHealClicked()
    {
        delayContext.ChangeAbility<DelayedHealAbility>();
    }

    public void OnRageClicked()
    {
        delayContext.ChangeAbility<DelayedRageAbility>();
    }


}
