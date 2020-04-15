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

        Player1.GetComponent<Player>().CollectCards();
        Player2.GetComponent<Player>().CollectCards();

        //Player1.GetComponent<Player>().Hand[0].Cn = Cards.CardNum.JACK;
        //Player1.GetComponent<Player>().Hand[0].suit = Cards.Suits.CLUBS;
        //Player1.GetComponent<Player>().Hand[1].Cn = Cards.CardNum.NINE;
        //Player1.GetComponent<Player>().Hand[1].suit = Cards.Suits.HEARTS;

        //Player2.GetComponent<Player>().Hand[0].Cn = Cards.CardNum.JACK;
        //Player2.GetComponent<Player>().Hand[0].suit = Cards.Suits.SPADES;
        //Player2.GetComponent<Player>().Hand[1].Cn = Cards.CardNum.FOUR;
        //Player2.GetComponent<Player>().Hand[1].suit = Cards.Suits.DIAMONDS;

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
            //Check for flush if the table cards are already a flush resulting in tie
            if(Player1.GetComponent<Player>().dhand == Player.DHand.FLUSH)
            {
                int counter = 0;
                int[] Player1Flush = Player1.GetComponent<Player>().SortBigtoSmall();
                int[] Player2Flush =  Player2.GetComponent<Player>().SortBigtoSmall();

                

                for(int x = 0; x <= 5; x++)
                {
                    if(Player1Flush[x] == Player2Flush[x])
                    {
                        counter++;
                    }
                    else
                    {
                        if(Player1Flush[x] > Player2Flush[x])
                        {
                            GameOverText.GetComponent<Text>().text = "Player 1 Wins!";
                        }
                        else if(Player2Flush[x] > Player1Flush[x])
                        {
                            GameOverText.GetComponent<Text>().text = "Player 2 Wins!";
                        }
                    }
                }
                if(counter == 5)
                {
                    GameOverText.GetComponent<Text>().text = "Its a tie!";
                }
            }
            else if(Player1.GetComponent<Player>().GetHighestCard() > Player2.GetComponent<Player>().GetHighestCard())
            {
                GameOverText.GetComponent<Text>().text = "Player 1 Wins!";
            }
            else if (Player1.GetComponent<Player>().GetHighestCard() == Player2.GetComponent<Player>().GetHighestCard() &&
                Player1.GetComponent<Player>().dhand == Player.DHand.TWOPAIR)
            {
                Cards.CardNum temp1 = Cards.CardNum.DEFAULT;
                Cards.CardNum temp2 = Cards.CardNum.DEFAULT;

                for (int i = 0; i < Player1.GetComponent<Player>().GetFullHand().Length; i++)
                {
                    for (int j = i + 1; j < Player1.GetComponent<Player>().GetFullHand().Length; j++)
                    {
                        //Pair check
                        if (Player1.GetComponent<Player>().GetFullHand()[i].Cn == Player1.GetComponent<Player>().GetFullHand()[j].Cn)
                        {
                            if (Player1.GetComponent<Player>().GetFullHand()[i].Cn != Player1.GetComponent<Player>().GetHighestCard())
                            {
                                temp1 = Player1.GetComponent<Player>().GetFullHand()[i].Cn;
                            }
                            
                        }

                        if (Player2.GetComponent<Player>().GetFullHand()[i].Cn == Player2.GetComponent<Player>().GetFullHand()[j].Cn)
                        {
                            if (Player2.GetComponent<Player>().GetFullHand()[i].Cn != Player2.GetComponent<Player>().GetHighestCard())
                            {
                                temp2 = Player2.GetComponent<Player>().GetFullHand()[i].Cn;
                            }

                        }


                    }
                }

                if(temp1 > temp2)
                {
                    GameOverText.GetComponent<Text>().text = "Player 1 Wins";
                }
                else if (temp1 < temp2)
                {
                    GameOverText.GetComponent<Text>().text = "Player 2 Wins";
                }
            }
            else if(Player1.GetComponent<Player>().GetHighestCard() == Player2.GetComponent<Player>().GetHighestCard())
            {
                Cards.CardNum temp1 = Cards.CardNum.DEFAULT;
                Cards.CardNum temp2 = Cards.CardNum.DEFAULT;
                for (int i = 0; i < Player1.GetComponent<Player>().Hand.Length; i++)
                {
                    if (temp1 == Cards.CardNum.DEFAULT)
                    {
                        temp1 = Player1.GetComponent<Player>().Hand[i].Cn;
                    }
                    else if(temp1 < Player1.GetComponent<Player>().Hand[i].Cn)
                    {
                        temp1 = Player1.GetComponent<Player>().Hand[i].Cn;
                    }
                    if(temp2 == Cards.CardNum.DEFAULT)
                    {
                        temp2 = Player2.GetComponent<Player>().Hand[i].Cn;
                    }
                    else if(temp2 < Player2.GetComponent<Player>().Hand[i].Cn)
                    {
                        temp2 = Player2.GetComponent<Player>().Hand[i].Cn;
                    }
                    if(temp1 == temp2 && i == 1 && temp1 == Player1.GetComponent<Player>().Hand[i].Cn)
                    {
                        temp1 = Player1.GetComponent<Player>().Hand[0].Cn;
                        temp2 = Player2.GetComponent<Player>().Hand[0].Cn;
                    }
                    else if(temp1 == temp2 && i == 1 && temp1 != Player1.GetComponent<Player>().Hand[i].Cn)
                    {
                        temp1 = Player1.GetComponent<Player>().Hand[i].Cn;
                        temp2 = Player2.GetComponent<Player>().Hand[i].Cn;
                    }
                    
                }

                if(temp1 > temp2)
                {
                    GameOverText.GetComponent<Text>().text = "Player 1 Wins";
                }
                else if(temp1 < temp2)
                {
                    GameOverText.GetComponent<Text>().text = "Player 2 Wins";
                }
                else if (temp1 == temp2)
                {
                    GameOverText.GetComponent<Text>().text = "Its a tie!";
                }

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
