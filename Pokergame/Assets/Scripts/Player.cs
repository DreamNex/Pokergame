using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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
    public GameObject HandofPlayer;

    private Cards[] fullHand = new Cards[7];
    private Cards.CardNum HighestCard;
    private int groupIter;
    // Start is called before the first frame update
    void Start()
    {
        groupIter = 0;
        dhand = DHand.DDEFAULT;
        HighestCard = Cards.CardNum.DEFAULT;
    }

    public void CollectCards()
    {
        for (int i = 0; i < Hand.Length; i++)
        {
            fullHand[i] = Hand[i];
        }
        for (int i = 2; i < 7; i++)
        {
            fullHand[i] = TableC[i - 2];
        }
    }
    public int[] SortBigtoSmall()
    {
        int[] temparray = new int[7];
        int spadecounter = 0;
        int clubscounter = 0;
        int heartscounter = 0;
        int daimcounter = 0;
        int counter = 0;
        for (int x = 0; x < fullHand.Length; x++)
        {
            switch(fullHand[x].suit)
            {
                case Cards.Suits.DIAMONDS:
                    {
                        daimcounter++;
                        break;
                    }

                case Cards.Suits.SPADES:
                    {
                        spadecounter++;
                        break;
                    }

                case Cards.Suits.CLUBS:
                    {
                        clubscounter++;
                        break;
                    }

                case Cards.Suits.HEARTS:
                    {
                        heartscounter++;
                        break;
                    }
            }
            
        }
        if (spadecounter >= 5)
        {
            for (int x = 0; x < fullHand.Length; x++)
            {
                if(fullHand[x].suit == Cards.Suits.SPADES)
                {
                    temparray[x] = (int)fullHand[x].Cn;
                    counter++;
                }
            }
        }
        else if (daimcounter >= 5)
        {
            for (int x = 0; x < fullHand.Length; x++)
            {
                if (fullHand[x].suit == Cards.Suits.DIAMONDS)
                {
                    temparray[x] = (int)fullHand[x].Cn;
                    counter++;
                }
            }
        }
        else if (clubscounter >= 5)
        {
            for (int x = 0; x < fullHand.Length; x++)
            {
                if (fullHand[x].suit == Cards.Suits.CLUBS)
                {
                    temparray[x] = (int)fullHand[x].Cn;
                    counter++;
                }
            }

        }

        else if (heartscounter >= 5)
        {
            for (int x = 0; x < fullHand.Length; x++)
            {
                if (fullHand[x].suit == Cards.Suits.HEARTS)
                {
                    temparray[x] = (int)fullHand[x].Cn;
                    counter++;
                }
            }
        }
        for (int x = 0; x <= counter; x++)
        {
            for (int i = x + 1; i <= counter; i++)
            {
                if (temparray[x] < temparray[i])
                {
                    int temp;
                    temp = temparray[x];
                    temparray[i] = temparray[x];
                    temparray[x] = temp;
                }
            }
        }
        return temparray;

    }
    public void SortCards()
    {


        //fullHand[0].Cn = Cards.CardNum.TEN;
        //fullHand[0].suit = Cards.Suits.HEARTS;

        //fullHand[1].Cn = Cards.CardNum.KING;
        //fullHand[1].suit = Cards.Suits.HEARTS;

        //fullHand[2].Cn = Cards.CardNum.FIVE;
        //fullHand[2].suit = Cards.Suits.HEARTS;

        //fullHand[3].Cn = Cards.CardNum.TWO;
        //fullHand[3].suit = Cards.Suits.SPADES;

        //fullHand[4].Cn = Cards.CardNum.TEN;
        //fullHand[4].suit = Cards.Suits.CLUBS;

        //fullHand[5].Cn = Cards.CardNum.TEN;
        //fullHand[5].suit = Cards.Suits.CLUBS;

        //fullHand[6].Cn = Cards.CardNum.EIGHT;
        //fullHand[6].suit = Cards.Suits.DIAMONDS;

        for (int x = 0; x < fullHand.Length; x++)
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
    public Cards[] GetFullHand()
    {
        return fullHand;
    }
    public Cards.CardNum GetHighestCard()
    {
        return HighestCard;
    }
    bool isPair()
    {
        HighestCard = Cards.CardNum.DEFAULT;
        for (int i = 0; i < fullHand.Length; i++)
        {
            for (int j = i + 1; j < fullHand.Length; j++)
            {
                if (fullHand[i].Cn == fullHand[j].Cn)
                {
                    if (HighestCard != Cards.CardNum.DEFAULT && HighestCard < fullHand[i].Cn)
                    {
                        HighestCard = fullHand[i].Cn;
                    }
                    else if (HighestCard == Cards.CardNum.DEFAULT)
                    {
                        HighestCard = fullHand[i].Cn;
                    }
                    return true;
                }
            }
        }
        return false;
    }
    bool isPair(int index)
    {
        for (int i = index; i < fullHand.Length; i++)
        {
            for (int j = i + 1; j < fullHand.Length; j++)
            {
                if (fullHand[i].Cn == fullHand[j].Cn)
                {
                    return true;
                }
            }
        }
        return false;
    }
    bool is2Pair()
    {
        HighestCard = Cards.CardNum.DEFAULT;
        int cardcounter = 0;
        for (int i = 0; i < fullHand.Length; i++)
        {
            for (int j = i + 1; j < fullHand.Length; j++)
            {
                //Pair check
                if (fullHand[i].Cn == fullHand[j].Cn)
                {
                    if (HighestCard != Cards.CardNum.DEFAULT && HighestCard < fullHand[i].Cn)
                    {
                        HighestCard = fullHand[i].Cn;
                    }
                    else if (HighestCard == Cards.CardNum.DEFAULT)
                    {
                        HighestCard = fullHand[i].Cn;
                    }
                    cardcounter++;
                    break;
                }

            }
        }
        if (cardcounter >= 2)
        {
            return true;
        }
        return false;
    }
    bool isFullHouse()
    {
        HighestCard = Cards.CardNum.DEFAULT;
        int index = 0;
        for (int i = 0; i < 3; i++)
        {
            int cardcounter = 0;
            for (int j = i + 1; j < fullHand.Length; j++)
            {
                if (fullHand[i].Cn == fullHand[j].Cn)
                {
                    index = j;
                    cardcounter++;
                }

            }

            if (cardcounter == 2)
            {
                if (HighestCard != Cards.CardNum.DEFAULT && HighestCard < fullHand[i].Cn)
                {
                    HighestCard = fullHand[i].Cn;
                }
                else if (HighestCard == Cards.CardNum.DEFAULT)
                {
                    HighestCard = fullHand[i].Cn;
                }

                if(isPair(index))
                {
                    return true;
                }
                
            }
        }

        return false;
    }
    bool isFullHouse2()
    {
        for (int i = 0; i < fullHand.Length; i++)
        {
            for (int j = i + 1; j < fullHand.Length; j++)
            {
                if (fullHand[i].Cn == fullHand[j].Cn)
                {
                    if(isThreeOKind(j))
                    {
                        return true;
                    }
                    
                }
            }
        }
        return false;
    }
    bool isThreeOKind()
    {
        HighestCard = Cards.CardNum.DEFAULT;
        groupIter = 5;
        for (int i = 0; i < groupIter; i++)
        {
            int cardcounter = 0;
            for (int j = i + 1; j < fullHand.Length; j++)
            {
                if (fullHand[i].Cn == fullHand[j].Cn)
                {

                    cardcounter++;
                }

            }

            if (cardcounter == 2)
            {
                if (HighestCard != Cards.CardNum.DEFAULT && HighestCard < fullHand[i].Cn)
                {
                    HighestCard = fullHand[i].Cn;
                }
                else if (HighestCard == Cards.CardNum.DEFAULT)
                {
                    HighestCard = fullHand[i].Cn;
                }
                return true;
            }
        }

        return false;
    }
    bool isThreeOKind(int index)
    {
        HighestCard = Cards.CardNum.DEFAULT;
        groupIter = 5;
        for (int i = index; i < groupIter; i++)
        {
            int cardcounter = 0;
            for (int j = i + 1; j < fullHand.Length; j++)
            {
                if (fullHand[i].Cn == fullHand[j].Cn)
                {
                    cardcounter++;
                }

            }

            if (cardcounter == 2)
            {
                if (HighestCard != Cards.CardNum.DEFAULT && HighestCard < fullHand[i].Cn)
                {
                    HighestCard = fullHand[i].Cn;
                }
                else if (HighestCard == Cards.CardNum.DEFAULT)
                {
                    HighestCard = fullHand[i].Cn;
                }
                return true;
            }
        }
        return false;
    }
    bool isFourOKind()
    {
        HighestCard = Cards.CardNum.DEFAULT;
        groupIter = 4;
        for (int i = 0; i < groupIter; i++)
        {
            int cardcounter = 0;
            for (int j = i + 1; j < fullHand.Length; j++)
            {
                if(fullHand[i].Cn == fullHand[j].Cn)
                {

                    cardcounter++;
                }

            }

            if (cardcounter == 3)
            {
                HighestCard = fullHand[i].Cn;
                return true;
            }
        }
        
        return false;
    }
    bool isStraight()
    {
        for (int i = (int)Cards.CardNum.ACE; i >= 0; i--)
        {
            if (i >= (int)Cards.CardNum.JACK && i <= (int)Cards.CardNum.KING)
            {
                continue;
            }
            if (CheckCardInHand((Cards.CardNum)i))
            {

                for (int j = 1; j < 5; j++)
                {
                    if (!CheckCardInHand((Cards.CardNum)((i + j) % 13)))
                    {
                        break;
                    }

                    if (j == 4)
                    {
                        HighestCard = (Cards.CardNum)((i + j) % 13);
                        return true;
                    }
                }
            }

        }
        
        return false;
    }
    bool isFlush()
    {
        HighestCard = Cards.CardNum.DEFAULT;
        for (int i = 0; i < fullHand.Length; i++)
        {
            int suitcounter = 0;
            for (int j = i + 1; j < fullHand.Length; j++)
            {
                //Pair check
                if (fullHand[i].suit == fullHand[j].suit)
                {
                    //Setting of the highest card number
                    if (HighestCard != Cards.CardNum.DEFAULT && HighestCard < fullHand[i].Cn)
                    {
                        HighestCard = fullHand[i].Cn;
                    }
                    else if (HighestCard == Cards.CardNum.DEFAULT)
                    {
                        HighestCard = fullHand[i].Cn;
                    }
                    suitcounter++;
                    
                }

            }


            if (suitcounter >= 4)
            {
                return true;
            }
            else
            {
                suitcounter = 0;
                continue;
            }

        }
        
        return false;
    }
    bool isRoyalFlush()
    {
        int cardcounter = 0;
        if(isFlush())
        {
            for(int i = 0; i < fullHand.Length; i++)
            {
                switch(cardcounter)
                {
                    case 0:
                        {
                            if(fullHand[i].Cn == Cards.CardNum.TEN)
                            {
                                cardcounter++;
                            }
                            break;
                        }
                    case 1:
                        {
                            if (fullHand[i].Cn == Cards.CardNum.JACK)
                            {
                                cardcounter++;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (fullHand[i].Cn == Cards.CardNum.QUEEN)
                            {
                                cardcounter++;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (fullHand[i].Cn == Cards.CardNum.KING)
                            {
                                cardcounter++;
                            }
                            break;
                        }
                    case 4:
                        {
                            if (fullHand[i].Cn == Cards.CardNum.ACE)
                            {
                                cardcounter++;
                            }
                            break;
                        }
                }
            }
            if(cardcounter >= 5)
            {
                return true;
            }
        }
        
        return false;
    }
    bool CheckCardInHand(Cards.CardNum cn)
    {
        for(int x = 0; x < fullHand.Length; x++)
        {
            if(fullHand[x].Cn == cn)
            {
                return true;
            }
        }
        return false;
    }
    void SetHandText()
    {
        switch (dhand)
        {
            case DHand.HIGHCARD:
                {
                    HandofPlayer.GetComponent<Text>().text = "HAND: HIGHCARD";
                    break;
                }
            case DHand.ONEPAIR:
                {
                    HandofPlayer.GetComponent<Text>().text = "HAND: ONE PAIR";
                    break;
                }
            case DHand.TWOPAIR:
                {
                    HandofPlayer.GetComponent<Text>().text = "HAND: TWO PAIR";
                    break;
                }
            case DHand.THREEOFAKIND:
                {
                    HandofPlayer.GetComponent<Text>().text = "HAND: THREE OF A KIND";
                    break;
                }
            case DHand.STRAIGHT:
                {
                    HandofPlayer.GetComponent<Text>().text = "HAND: STRAIGHT";
                    break;
                }
            case DHand.FULLHOUSE:
                {
                    HandofPlayer.GetComponent<Text>().text = "HAND: FULLHOUSE";
                    break;
                }
            case DHand.FLUSH:
                {
                    HandofPlayer.GetComponent<Text>().text = "HAND: FLUSH";
                    break;
                }
            case DHand.FOUROFAKIND:
                {
                    HandofPlayer.GetComponent<Text>().text = "HAND: FOUR OF A KIND";
                    break;
                }
            case DHand.STRAIGHTFLUSH:
                {
                    HandofPlayer.GetComponent<Text>().text = "HAND: STRAIGHT FLUSH";
                    break;
                }
            case DHand.ROYALFLUSH:
                {
                    HandofPlayer.GetComponent<Text>().text = "HAND: ROYAL FLUSH";
                    break;
                }
        }
    }
    public void GetHand()
    {

        SortCards();
        if(isRoyalFlush())
        {
            dhand = DHand.ROYALFLUSH;
            SetHandText();
        }
        else if (isFlush() && isStraight())
        {
            dhand = DHand.STRAIGHTFLUSH;
            SetHandText();
        }
        else if (isFourOKind())
        {
            dhand = DHand.FOUROFAKIND;
            SetHandText();
        }
        else if (isFlush())
        {
            dhand = DHand.FLUSH;
            SetHandText();
        }
        else if (isFullHouse())  //22233 (three of a kind first then the pair)
        {
            dhand = DHand.FULLHOUSE;
            SetHandText();
        }
        else if(isFullHouse2()) //22333 (pair then a three of a kind)
        {
            dhand = DHand.FULLHOUSE;
            SetHandText();
        }
        else if(isStraight())
        {
            dhand = DHand.STRAIGHT;
            SetHandText();
        }
        else if (isThreeOKind())
        {
            dhand = DHand.THREEOFAKIND;
            SetHandText();
        }
        else if (is2Pair())
        {
            dhand = DHand.TWOPAIR;
            SetHandText();
        }
        else if (isPair())
        {
            dhand = DHand.ONEPAIR;
            SetHandText();
        }
        
        else //if (samecardcounter == 0 && sametypecounter == 0)
        {
            dhand = DHand.HIGHCARD;
            SetHandText();
        }
        
    }
   

}
