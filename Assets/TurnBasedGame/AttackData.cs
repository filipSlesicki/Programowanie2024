using UnityEngine;

public class AttackData
{
    public int Damage;
    public Unit Attacker;
    public Unit Receiver;

    public AttackData(int damage, Unit attacker, Unit receiver)
    {
        Damage = damage;
        Attacker = attacker;
        Receiver = receiver;
    }
}
