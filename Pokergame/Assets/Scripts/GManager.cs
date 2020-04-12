using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public Cards[] TableC;
    public GameObject Player1;
    public GameObject Player2;

    private GameObject Dec;
    private GameObject OriginalDec;
    private GameObject GameOverText;

    // Start is called before the first frame update
    void Start()
    {
        GameOverText = GameObject.FindGameObjectWithTag("GameOver");
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
        Player1.GetComponent<Player>().GetHand();
        Player2.GetComponent<Player>().GetHand();

        GetWinner();
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

    public void GetWinner()
    {
        if(Player1.GetComponent<Player>().dhand == Player2.GetComponent<Player>().dhand)
        {
            if(Player1.GetComponent<Player>().GetHighestCard() > Player2.GetComponent<Player>().GetHighestCard())
            {
                GameOverText.GetComponent<Text>().text = "Player 1 Wins!";
            }
            else if(Player1.GetComponent<Player>().GetHighestCard() == Player2.GetComponent<Player>().GetHighestCard())
            {
               GameOverText.GetComponent<Text>().text = "It's a tie!";
            }
            else
            {
                GameOverText.GetComponent<Text>().text = "Player 2 Wins";
            }
        }
        else if(Player1.GetComponent<Player>().dhand > Player2.GetComponent<Player>().dhand)
        {
            GameOverText.GetComponent<Text>().text = "Player 1 Wins!";
        }

        else if (Player1.GetComponent<Player>().dhand < Player2.GetComponent<Player>().dhand)
        {
            GameOverText.GetComponent<Text>().text = "Player 2 Wins!";
        }
    }
      
}
