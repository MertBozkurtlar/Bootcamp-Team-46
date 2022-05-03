using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new List<Card>();
    public int displayId;

    public int id;
    public string cardName;
    public int mana;
    public int attack;
    public int defense;
    public string cardDescription;

    public Text nameText;
    public Text manaText;
    public Text attackText;
    public Text defenseText;
    public Text descriptionText;



    // Start is called before the first frame update
    void Start()
    {
        displayCard[0] = CardDatabase.cardList[displayId];
    }

    // Update is called once per frame
    void Update()
    {
        id = displayCard[0].id;
        cardName = displayCard[0].cardName;
        mana = displayCard[0].mana;
        attack = displayCard[0].attack;
        defense = displayCard[0].defense;
        cardDescription = displayCard[0].cardDescription;

        nameText.text = " " + cardName;
        manaText.text = " " + mana;
        attackText.text = " " + attack;
        defenseText.text = " " + defense;
        descriptionText.text = " " + cardDescription;
        

    }
}
