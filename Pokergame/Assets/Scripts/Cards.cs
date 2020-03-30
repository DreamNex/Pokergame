﻿using System.Collections;
using System.Collections.Generic;
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

    public bool GetIsPlayed()
    {
        return Isplayed;
    }

    public void SetIsPlayed(bool b)
    {
        Isplayed = b;
    }
}
