using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class Card2 : ScriptableObject
{

    public new string name;
    public int manaCost;
    public int attack;
    public int defence;
    public string description;
    
    public void Print()
    {
        Debug.Log(name + ": " + description + " The card costs: " + manaCost);
    }



}


