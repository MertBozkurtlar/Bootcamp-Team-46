using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card : ScriptableObject
{

    public int id;
    public string cardName;
    public int mana;
    public int attack;
    public int defense;
    public string cardDescription;
    
    public Card()
    {



    }

    public Card(int Id, string CardName, int Mana, int Attack, int Defense, string CardDescription)
    {
        id = Id;
        cardName = CardName;
        mana = Mana;
        attack = Attack;
        defense = Defense;
        cardDescription = CardDescription;



    }






}
