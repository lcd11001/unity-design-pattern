using System.Collections;
using TMPro;
using UnityEngine;

public class RageAbility : MonoBehaviour, IAbility
{
    public void Use(IAbilityContext context)
    {
        Debug.Log("Use Rage");
        StartCoroutine(Display(context));
    }

    IEnumerator Display(IAbilityContext context)
    {
        TextMeshProUGUI txt = context.GetAbilityDisplay();
        txt.text = "Rage";
        yield return new WaitForSeconds(1);

        if (context.GetCurrentAbility() is RageAbility) 
        {
            Debug.Log("End RageAbility");
            txt.text = "";
        }
        else
        {
            Debug.Log("Ignore RageAbility");
        }
    }
}