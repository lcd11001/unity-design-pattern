using System.Collections;
using TMPro;
using UnityEngine;

public class DelayedHealAbility : BaseAbility
{
    public override void Use(IAbilityContext context)
    {
        Debug.Log("Use HealAbility");

        StartCoroutine(Display(context));
    }

    IEnumerator Display(IAbilityContext context)
    {
        TextMeshProUGUI template = context.GetAbilityDisplay();
        TextMeshProUGUI txt = Instantiate(template, template.transform.parent);
        txt.name = "Heal (clone)";
        float timer = duration;
        while(timer > 0)
        {
            txt.text = $"Heal {timer}";
            timer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Destroy(txt.gameObject);
    }
}