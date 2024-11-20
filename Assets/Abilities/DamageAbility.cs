using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Ability", menuName = "Battle/Abilities/DamageAbility")]
public class DamageAbility : ScriptableObject
{
    public float Damage;
    public string Name;
    public Sprite Icon;
    public string Description;
    public GameObject UseEffect;
    public AudioClip UseSound;

    public void Use(Health target)
    {
        target.ModifyHealth(-Damage);
    }
}