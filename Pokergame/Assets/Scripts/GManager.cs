using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public Cards[] P1Hand;
    public Cards[] P2Hand;
    public Cards[] TableC;

    private GameObject Dec;
    private GameObject OriginalDec;
    
    // Start is called before the first frame update
    void Start()
    {
        Dec = GameObject.FindGameObjectWithTag("Deck");
        OriginalDec = Dec;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealRound()
    {
        Dec = OriginalDec;
        Dec.GetComponent<Deck>().ResetDeck();
        Dec.GetComponent<Deck>().ShuffleDeck();

        DealCards();
    }

    public void DealCards()
    {
        //Give Players card first
        P1Hand[0].CopyCard(Dec.GetComponent<Deck>().GetTopCard());
        P1Hand[0].SetCardText(P1Hand[0].GetComponentInChildren<Text>());

        P2Hand[0].CopyCard(Dec.GetComponent<Deck>().GetTopCard());
        P2Hand[0].SetCardText(P2Hand[0].GetComponentInChildren<Text>());

        P1Hand[1].CopyCard(Dec.GetComponent<Deck>().GetTopCard());
        P1Hand[1].SetCardText(P1Hand[1].GetComponentInChildren<Text>());

        P2Hand[1].CopyCard(Dec.GetComponent<Deck>().GetTopCard());
        P2Hand[1].SetCardText(P2Hand[1].GetComponentInChildren<Text>());

        //Do Table Cards
        for (int i = 0; i < TableC.Length; i++)
        {
            TableC[i].CopyCard(Dec.GetComponent<Deck>().GetTopCard());
            TableC[i].SetCardText(TableC[i].GetComponentInChildren<Text>());
        }
    }
}
