using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Ability", menuName = "Battle/Abilities/DamageAbility")]
public class DamageAbility : ScriptableObject
{
    public float Damage;
    public float ManaCost;
    public string Name;
    public Sprite Icon;
    public string Description;
    public GameObject UseEffect;
    public AudioClip UseSound;

    public bool Use(Health target, Mana userMana)
    {
        if(userMana.currentMana >= ManaCost)
        {
            userMana.ModifyMana(-ManaCost);
            target.ModifyHealth(-Damage);
            return true;
        }
        Debug.Log("Not enough mana");
        return false;

    }
}