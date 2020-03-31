using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public Cards[] DeckofCards;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    public void ShuffleDeck()
    {
        for(int i = 0; i < DeckofCards.Length; i++)
        {
            Cards temp = DeckofCards[i];
            index = Random.Range(i, DeckofCards.Length);
            //DeckofCards[i].cardnumber = DeckofCards[index].cardnumber;
            //DeckofCards[i].cardtype = DeckofCards[index].cardtype;
            //DeckofCards[index].cardnumber = temp.cardnumber;
            //DeckofCards[index].cardtype = temp.cardtype;
            DeckofCards[i] = DeckofCards[index];
            DeckofCards[index] = temp;
        }
    }

    public Cards GetTopCard()
    {
        for(int i = 0; i < DeckofCards.Length; i++)
        {
            if(!DeckofCards[i].GetIsPlayed())
            {
                DeckofCards[i].SetIsPlayed(true);
                return DeckofCards[i];
            }
            else
            {
                continue;
            }
        }

        return null;
        
    }
    public void ResetDeck()
    {
        for(int i = 0; i < DeckofCards.Length; i++)
        {
            DeckofCards[i].SetIsPlayed(false);
        }
    }
}
