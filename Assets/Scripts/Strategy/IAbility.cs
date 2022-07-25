using System;
using TMPro;

public interface IAbility
{
    void Use(IAbilityContext context);
}

public interface IAbilityContext
{
    void ChangeAbility<T>() where T: IAbility;
    TextMeshProUGUI GetAbilityDisplay();
    IAbility GetCurrentAbility();
}
