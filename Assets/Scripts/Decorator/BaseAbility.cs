using UnityEngine;

public abstract class BaseAbility : MonoBehaviour, IAbility
{
    [SerializeField] protected float duration;
    public abstract void Use(IAbilityContext context);
}