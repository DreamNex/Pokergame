using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum DHand
    {
        HIGHCARD,
        ONEPAIR,
        TWOPAIR,
        THREEOFAKIND,
        STRAIGHT,
        FULLHOUSE,
        FLUSH,
        FOUROFAKIND,
        STRAIGHTFLUSH,
        ROYALFLUSH,
        DDEFAULT
    };

    [HideInInspector] public DHand dhand;
    public Cards[] Hand;
    public Cards[] TableC;

    private Cards[] fullHand = new Cards[7];
    private Cards HighestCard;
    // Start is called before the first frame update
    void Start()
    {
        dhand = DHand.DDEFAULT;
    }

    public void SortCards()
    {
        for(int i = 0; i < Hand.Length; i++)
        {
            fullHand[i] = Hand[i];
        }
        for(int i = 2; i < 8; i++)
        {
            fullHand[i] = Hand[i];
        }

        for(int x = 0; x < fullHand.Length; x++)
        {
            for(int i = x+1; i < fullHand.Length; i++)
            {
                if(fullHand[x].Cn > fullHand[i].Cn)
                {
                    Cards temp;
                    temp = fullHand[x];
                    fullHand[x] = fullHand[i];
                    fullHand[i] = temp;
                }
            }
        }
    }
    public Cards GetHighestCard()
    {
        return HighestCard;
    }
    public void GetHand()
    {

        int samecardcounter = 0;
        int sametypecounter = 0;

        SortCards();
        
        for (int i = 0; i < fullHand.Length; i++)
        {
            for (int j = i + 1; j < fullHand.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }
                //same card for how many pairs
                else if (fullHand[i].Cn == fullHand[j].Cn)
                {
                    if(HighestCard != null && HighestCard.Cn < fullHand[i].Cn)
                    {
                        HighestCard = fullHand[i];
                    }
                    else
                    {
                        HighestCard = fullHand[i];
                    }
                    samecardcounter++;
                }
                else if (fullHand[i].suit == fullHand[j].suit)
                {
                    sametypecounter++;
                }
            }
        }

        if (samecardcounter == 0 && sametypecounter == 0)
        {
            dhand = DHand.HIGHCARD;
        }
        else if (samecardcounter < 2 && samecardcounter > 0 && sametypecounter < 5)
        {
            dhand = DHand.ONEPAIR;
        }
        else if (samecardcounter == 2 && sametypecounter < 5)
        {
            dhand = DHand.TWOPAIR;
        }
        else if(samecardcounter == 3 && sametypecounter < 5)
        {
            dhand = DHand.THREEOFAKIND;
        }
        else if(samecardcounter == 4 && sametypecounter < 5)
        {
            dhand = DHand.FOUROFAKIND;
        }
    }
}
