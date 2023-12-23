using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerManager : MonoBehaviour
{

    protected static PlayerManager instance;
    public static PlayerManager Instance { get => instance; }

    [SerializeField] float coin;
    [SerializeField] TextMeshProUGUI coinTxt; 

    private void Start()
    {
        SetTextCoin();
    }
    public float GetCoin()
    {
        return coin;
    }

    public void SetCoin(float coin)
    {
        this.coin = coin;
    }

    public void AddCoin(float val)
    {
        coin += val;
        SetTextCoin();
    }

    public void MinusCoin(float val)
    {
        coin -= val;
        SetTextCoin();
    }

    public void SetTextCoin()
    {
        coinTxt.text = $"{coin}";
    }

}
