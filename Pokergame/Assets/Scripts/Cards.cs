using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Cards: MonoBehaviour
{
    public enum Suits
    {
        DIAMONDS,
        CLUBS,
        HEARTS,
        SPADES
    };
    public enum CardNum
    {
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,
        QUEEN,
        KING,
        ACE
    };

    public Suits suit;
    public CardNum Cn;

    private bool Isplayed;

    

    private void Awake()
    {
        Isplayed = false;
    }

    public void CopyCard(Cards ccard)
    {
        this.suit = ccard.suit;
        this.Cn = ccard.Cn;
    }
    public bool GetIsPlayed()
    {
        return Isplayed;
    }
    public void SetCardText(Text ttext)
    {
        switch(Cn)
        {
            case CardNum.TWO:
                {
                    ttext.text = "2" + System.Environment.NewLine;
                }
                break;

            case CardNum.THREE:
                {
                    ttext.text = "3" + System.Environment.NewLine;
                }
                break;

            case CardNum.FOUR:
                {
                    ttext.text = "4" + System.Environment.NewLine;
                }
                break;

            case CardNum.FIVE:
                {
                    ttext.text = "5" + System.Environment.NewLine;
                }
                break;

            case CardNum.SIX:
                {
                    ttext.text = "6" + System.Environment.NewLine;
                }
                break;

            case CardNum.SEVEN:
                {
                    ttext.text = "7" + System.Environment.NewLine;
                }
                break;

            case CardNum.EIGHT:
                {
                    ttext.text = "8" + System.Environment.NewLine;
                }
                break;

            case CardNum.NINE:
                {
                    ttext.text = "9" + System.Environment.NewLine;
                }
                break;

            case CardNum.TEN:
                {
                    ttext.text = "10" + System.Environment.NewLine;
                }
                break;

            case CardNum.JACK:
                {
                    ttext.text = "J" + System.Environment.NewLine;
                }
                break;

            case CardNum.QUEEN:
                {
                    ttext.text = "Q" + System.Environment.NewLine;
                }
                break;

            case CardNum.KING:
                {
                    ttext.text = "K" + System.Environment.NewLine;
                }
                break;

            case CardNum.ACE:
                {
                    ttext.text = "A" + System.Environment.NewLine;
                }
                break;

        }

        switch(suit)
        {
            case Suits.CLUBS:
                {
                    ttext.text += "Clubs";
                }
                break;

            case Suits.DIAMONDS:
                {
                    ttext.text += "Diamonds";
                }
                break;

            case Suits.HEARTS:
                {
                    ttext.text += "Hearts";
                }
                break;

            case Suits.SPADES:
                {
                    ttext.text += "Spades";
                }
                break;
        }
    }
    public void SetIsPlayed(bool b)
    {
        Isplayed = b;
    }
}
