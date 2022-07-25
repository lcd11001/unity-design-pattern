using System.Collections;
using TMPro;
using UnityEngine;

public class DelayedRageAbility : BaseAbility
{
    public override void Use(IAbilityContext context)
    {
        Debug.Log("Use Rage");
        StartCoroutine(Display(context));
    }

    IEnumerator Display(IAbilityContext context)
    {
        TextMeshProUGUI template = context.GetAbilityDisplay();
        TextMeshProUGUI txt = Instantiate(template, template.transform.parent);
        txt.name = "Rage (clone)";
        float timer = duration;
        while(timer > 0)
        {
            txt.text = $"Rage {timer}";
            timer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Destroy(txt.gameObject);
    }
}