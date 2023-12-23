using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PetModel
{
    public string namePet;
    public float price;
    public float remainingTime = 6;
    public float remainingTimeChoAn;
    public float timeChoAn;
    public float timeDeTrung = 5;
    public float speed = 1;


    internal float GetCoinSell()
    {
        return price;
    }  

}
