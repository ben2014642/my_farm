using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PetModel
{
    public int price;
    public float remainingTime = 6;
    public float remainingTimeChoAn;
    public float timeChoAn = 5;
    public float speed = 1;

    internal int GetCoinSell()
    {
        return price;
    }
    
}
