using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerModel
{
    [SerializeField] int coint;

    public int GetCoin()
    {
        return coint;
    }

    public void AddCoin(int val)
    {
        coint += val;
    }

}
