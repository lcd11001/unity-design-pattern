using System.Collections;
using TMPro;
using UnityEngine;

public class HealAbility : MonoBehaviour, IAbility
{
    public void Use(IAbilityContext context)
    {
        Debug.Log("Use HealAbility");

        StartCoroutine(Display(context));
    }

    IEnumerator Display(IAbilityContext context)
    {
        TextMeshProUGUI txt = context.GetAbilityDisplay();
        txt.text = "Heal";
        yield return new WaitForSeconds(1);

        if (context.GetCurrentAbility() is HealAbility) 
        {
            Debug.Log("End HealAbility");
            txt.text = "";
        }
        else
        {
            Debug.Log("Ignore HealAbility");
        }
    }
}