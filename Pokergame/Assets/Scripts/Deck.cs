using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public Cards[] DeckofCards = new Cards[52];
    // Start is called before the first frame update
    void Start()
    {

    }

    public void ShuffleDeck()
    {
        for(int i = 0; i < DeckofCards.Length; i++)
        {
            Cards temp = DeckofCards[i];
            int index = Random.Range(i, DeckofCards.Length);
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
}
