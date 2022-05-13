using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{

    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "Enemy1", 0, 0, 0, "This is an enemy", Resources.Load<Sprite>("cardArt1") ));
        cardList.Add(new Card(1, "Enemy2", 1, 0, 0, "This is an enemy", Resources.Load<Sprite>("cardArt2") ));
        cardList.Add(new Card(2, "Enemy3", 2, 0, 0, "This is an enemy", Resources.Load<Sprite>("cardArt2") ));
        cardList.Add(new Card(3, "Enemy4", 3, 0, 0, "This is an enemy", Resources.Load<Sprite>("cardArt2") ));

    }


}
