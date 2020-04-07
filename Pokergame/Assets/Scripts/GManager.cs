using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public Cards[] P1Hand;
    public Cards[] P2Hand;
    public Cards[] TableC;

    public GameObject Player1;
    public GameObject Player2;

    private GameObject Dec;
    private GameObject OriginalDec;

    // Start is called before the first frame update
    void Start()
    {
        Dec = GameObject.FindGameObjectWithTag("Deck");
        OriginalDec = Dec;

    }

    public void DealRound()
    {
        Dec = OriginalDec;
        Dec.GetComponent<Deck>().ResetDeck();
        Dec.GetComponent<Deck>().ShuffleDeck();

        DealCards();
        
        //Player1.GetComponent<Player>().SortCards();
        //Player2.GetComponent<Player>().SortCards();
    }

    public void DealCards()
    {
        //Give Players card first
        for (int i = 0; i < Player1.GetComponent<Player>().Hand.Length; i++)
        {
            Player1.GetComponent<Player>().Hand[i].CopyCard(Dec.GetComponent<Deck>().GetTopCard());
            Player1.GetComponent<Player>().Hand[i].SetCardText(Player1.GetComponent<Player>().Hand[i].GetComponentInChildren<Text>());

            Player2.GetComponent<Player>().Hand[i].CopyCard(Dec.GetComponent<Deck>().GetTopCard());
            Player2.GetComponent<Player>().Hand[i].SetCardText(Player2.GetComponent<Player>().Hand[i].GetComponentInChildren<Text>());
        }

        //Do Table Cards
        for (int i = 0; i < TableC.Length; i++)
        {
            TableC[i].CopyCard(Dec.GetComponent<Deck>().GetTopCard());
            TableC[i].SetCardText(TableC[i].GetComponentInChildren<Text>());
        }
    }

      

}
