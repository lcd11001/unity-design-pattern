using System.Collections;
using TMPro;
using UnityEngine;

public class FireBallAbility : MonoBehaviour, IAbility
{
    public void Use(IAbilityContext context)
    {
        Debug.Log("Use FireBallAbility");

        StartCoroutine(Display(context));
    }

    IEnumerator Display(IAbilityContext context)
    {
        TextMeshProUGUI txt = context.GetAbilityDisplay();
        txt.text = "Fireball";

        yield return new WaitForSeconds(1);

        if (context.GetCurrentAbility() is FireBallAbility) 
        {
            Debug.Log("End FireBallAbility");
            txt.text = "";
        }
        else
        {
            Debug.Log("Ignore FireBallAbility");
        }
    }
}