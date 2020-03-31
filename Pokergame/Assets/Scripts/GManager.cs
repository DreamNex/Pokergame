using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public GameObject[] P1Hand;
    public GameObject[] P2Hand;
    public GameObject[] TableC;

    private GameObject Dec;
    
    // Start is called before the first frame update
    void Start()
    {
        Dec = GameObject.FindGameObjectWithTag("Deck");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealRound()
    {
        Dec.GetComponent<Deck>().ShuffleDeck();

        DealCards();
    }

    public void DealCards()
    {
        //Give Players card first
        //Do Table Cards
    }
}
