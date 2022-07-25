using TMPro;
using UnityEngine;

public abstract class BaseContext : MonoBehaviour, IAbilityContext
{
    public abstract void ChangeAbility<T>() where T : IAbility;
    public abstract TextMeshProUGUI GetAbilityDisplay();
    public abstract IAbility GetCurrentAbility();
}