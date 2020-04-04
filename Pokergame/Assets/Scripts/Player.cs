using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum DHand
    {
        ROYALFLUSH,
        STRAIGHTFLUSH,
        FOUROFAKIND,
        FLUSH,
        FULLHOUSE,
        STRAIGHT,
        THREEOFAKIND,
        TWOPAIR,
        ONEPAIR,
        HIGHCARD,
        DDEFAULT
    };

    [HideInInspector] public DHand dhand;
    public Cards[] Hand;

    // Start is called before the first frame update
    void Start()
    {
        dhand = DHand.DDEFAULT;
    }

}
