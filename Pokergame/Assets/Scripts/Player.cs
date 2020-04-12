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
    // Start is called before the first frame update
    void Start()
    {
        dhand = DHand.DDEFAULT;
        HighestCard = Cards.CardNum.DEFAULT;
    }

    public void SortCards()
    {
        for(int i = 0; i < Hand.Length; i++)
        {
            fullHand[i] = Hand[i];
        }
        for(int i = 2; i < 7; i++)
        {
            fullHand[i] = TableC[i - 2];
        }

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
    public Cards.CardNum GetHighestCard()
    {
        return HighestCard;
    }
    bool isPair()
    {
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
                }

            }
        }
        if (cardcounter == 2)
        {
            return true;
        }
        return false;
    }
    bool isFullHouse()
    {
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

        for (int i = 0; i < 3; i++)
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
        for (int i = index; i < 3; i++)
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
        
        for (int i = 0; i < 4; i++)
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
        
        for(int i = (int)Cards.CardNum.ACE; i >= 0 ; i--)
        {
            if (i >= (int)Cards.CardNum.JACK && i <= (int)Cards.CardNum.KING)
            {
                continue;
            }
            if (CheckCardInHand((Cards.CardNum)i))
            {
                
                for(int j = 1; j < 5; j++)
                {
                    if(!CheckCardInHand((Cards.CardNum)((i + j) % 13)))
                    {
                        break;
                    }
                    
                    if(j == 4)
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
