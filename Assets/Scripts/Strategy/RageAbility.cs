using System.Collections;
using TMPro;
using UnityEngine;

public class RageAbility : IAbility
{
    public void Use(IAbilityContext context)
    {
        Debug.Log("Use Rage");
        Display(context);
    }

    void Display(IAbilityContext context)
    {
        TextMeshProUGUI txt = context.GetAbilityDisplay();
        txt.text = "Rage";
    }
}