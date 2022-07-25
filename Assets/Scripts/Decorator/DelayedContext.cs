using TMPro;
using UnityEngine;

public class DelayedContext : BaseContext
{
    [SerializeField] BaseAbility wrappedAbility;
    [SerializeField] TextMeshProUGUI abilityText;

    public override void ChangeAbility<T>()
    {
        wrappedAbility = GetComponentInChildren<T>() as BaseAbility;

        wrappedAbility.Use(this);
    }

    public override TextMeshProUGUI GetAbilityDisplay()
    {
        return abilityText;
    }

    public override IAbility GetCurrentAbility()
    {
        return wrappedAbility;
    }
}