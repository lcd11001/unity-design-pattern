using System.Collections;
using TMPro;
using UnityEngine;

public class FireBallAbility : IAbility
{
    public void Use(IAbilityContext context)
    {
        Debug.Log("Use FireBallAbility");

        Display(context);
    }

    void Display(IAbilityContext context)
    {
        TextMeshProUGUI txt = context.GetAbilityDisplay();
        txt.text = "Fireball";
    }
}