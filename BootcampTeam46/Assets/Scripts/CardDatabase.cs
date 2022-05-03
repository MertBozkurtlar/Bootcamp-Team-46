using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{

    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "None", 0, 0, 0, "None"));
        cardList.Add(new Card(0, "None", 1, 0, 0, "None"));
        cardList.Add(new Card(0, "None", 2, 0, 0, "None"));
        cardList.Add(new Card(0, "None", 3, 0, 0, "None"));

    }


}
