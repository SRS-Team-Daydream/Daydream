using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int max_Hp;
    public int current_Hp;

    public int max_Armor;
    public int current_Armor;

    //Only Enemies Use
    public int statecount;

    //Only Players Use
    public int abacusCount;
    public int abacusMax;

    public (string, (int, int, int), int) attack;
    public (string, (int, int, int), int) heal;
    public (string, int)                  buff;
    public (string, int)                  debuff;

    public bool TakeDamage(int dmg)
    {
        current_Hp -= dmg;
        if(current_Hp <= 0) 
            return true;
        else
            return false;
    }

    public void Heal(int hp)
    {
        int healing = current_Hp + hp;
        if(healing > max_Hp)
            current_Hp = max_Hp;
        else
            current_Hp = healing;

    }

    public void StatusEffect(string effect)
    {

        if(effect == "Block")
            Block(Random.Range(1, 5));
        if (effect == "Shred")
            Shred(Random.Range(1, 7));
    }

   void Block(int armor)
    {
        int arm = current_Armor + armor;
        if (arm > max_Armor)
            current_Armor = max_Armor;
        else
            current_Armor = arm;
    }

    void Shred(int strip)
    {
        int str = current_Armor - strip;
        if (str < 0)
            current_Armor = 0;
        else
            current_Armor = str;
    }


}
