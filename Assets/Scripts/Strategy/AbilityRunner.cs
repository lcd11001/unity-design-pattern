using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AbilityRunner : MonoBehaviour, IAbilityContext
{
    // public enum Ability
    // {
    //     FireBall,
    //     Rage,
    //     Heal
    // }
    // [SerializeField] Ability currentAbility = Ability.FireBall;

    IAbility currentAbility;
    public TextMeshProUGUI abilityText;

    public void ChangeAbility<T>() where T : IAbility
    {
        currentAbility = Activator.CreateInstance<T>();

        UseAbility();
    }

    public TextMeshProUGUI GetAbilityDisplay()
    {
        return abilityText;
    }

    public IAbility GetCurrentAbility()
    {
        return currentAbility;
    }

    public void UseAbility()
    {
        // switch (currentAbility)
        // {
        //     case Ability.FireBall:
        //         Debug.Log("Use FireBall");
        //         break;

        //     case Ability.Rage:
        //         Debug.Log("Use Rage");
        //         break;

        //     case Ability.Heal:
        //         Debug.Log("Use Heal");
        //         break;
        // }

        currentAbility.Use(this);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            ChangeAbility<FireBallAbility>();
        }
        else if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            ChangeAbility<HealAbility>();
        }
        else if (Input.GetKeyUp(KeyCode.Keypad3))
        {
            ChangeAbility<RageAbility>();
        }
    }

    public void OnFireBallClicked()
    {
        ChangeAbility<FireBallAbility>();
    }

    public void OnHealClicked()
    {
        ChangeAbility<HealAbility>();
    }

    public void OnRageClicked()
    {
        ChangeAbility<RageAbility>();
    }


}
