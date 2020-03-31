using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Cards : MonoBehaviour
{
    public string cardnumber;
    public string cardtype;
    private bool Isplayed;

    private void Awake()
    {
        Isplayed = false;
    }

    public void ResetCard()
    {
        cardnumber = " ";
        cardtype = " ";
    }
    public void CopyCard(Cards ccard)
    {
        this.cardnumber = ccard.cardnumber;
        this.cardtype = ccard.cardtype;
    }
    public bool GetIsPlayed()
    {
        return Isplayed;
    }
    public void SetCardText(Text ttext)
    {
        ttext.text = cardnumber + System.Environment.NewLine + cardtype;
    }
    public void SetIsPlayed(bool b)
    {
        Isplayed = b;
    }
}
