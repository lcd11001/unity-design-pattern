using System.Collections;
using TMPro;
using UnityEngine;

public class HealAbility : IAbility
{
    public void Use(IAbilityContext context)
    {
        Debug.Log("Use HealAbility");

        Display(context);
    }

    void Display(IAbilityContext context)
    {
        TextMeshProUGUI txt = context.GetAbilityDisplay();
        txt.text = "Heal";
    }
}