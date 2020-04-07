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

    public void GetHand()
    {
        SortCards();
        int samecardcounter = 0;
        int sametypecounter = 0;

        for(int i = 0; i < fullHand.Length; i++)
        {
            for(int j = i + 1; j < fullHand.Length; j++)
            {
                if(i == j)
                {
                    continue;
                }
                //same card for how many pairs
                else if(fullHand[i].Cn == fullHand[j].Cn)
                {
                    samecardcounter++;
                }
            }
        }
    }
}
