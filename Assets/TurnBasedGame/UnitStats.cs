using UnityEngine;
using System;

[Serializable]
public class UnitStats 
{
    public int Attack;
    public int Defense;

    public UnitStats(int attack, int defense)
    {
        Attack = attack; 
        Defense = defense;
        Debug.Log("Created unit stats");
    }

    public UnitStats(int attack, float defense)
    {
        Attack = attack;
        Defense = (int)defense;
        Debug.Log("Created unit stats");
    }

    public UnitStats(int attack)
    {
        Attack = attack;
        Debug.Log("Created unit stats");
    }
}
