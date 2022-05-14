using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Card
{

    public int id;
    public string cardName;
    public int mana;
    public int attack;
    public int defense;
    public string cardDescription;
    public Sprite spriteImage;

    
    public Card()
    {



    }

    public Card(int Id, string CardName, int Mana, int Attack, int Defense, string CardDescription, Sprite SpriteImage)
    {
        id = Id;
        cardName = CardName;
        mana = Mana;
        attack = Attack;
        defense = Defense;
        cardDescription = CardDescription;
        spriteImage = SpriteImage;



    }






}
