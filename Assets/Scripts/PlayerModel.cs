using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerModel : MonoBehaviour
{

    protected static PlayerModel instance;
    public static PlayerModel Instance { get => instance; }

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
