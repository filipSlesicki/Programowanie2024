using UnityEngine;

public static class DamageCalcculator 
{
    public static int CalculateDamage(AttackData attackData)
    {
        int damage = attackData.Damage;
        damage += attackData.Attacker.Stats.Attack;
        damage -= attackData.Receiver.Stats.Defense;
        return damage;
    }
}
