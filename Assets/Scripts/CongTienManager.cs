using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CongTienManager : MonoBehaviour
{
    public static CongTienManager instance;
    [SerializeField] GameObject congTienPrefab;
    [SerializeField] protected PlayerManager playerManager;
    //int sumcoint = 0;
    private void Awake()
    {
        instance = this;
    }
    public void CreateText(Vector2 position, float coint)
    {
        var obj = PoolManager.GetObj("congtien", congTienPrefab);
        obj.transform.position = position;
        obj.GetComponent<CongTien>().SetText($"{(coint >= 0 ? "+" : ' ')} {coint} Coin");
        playerManager.AddCoin(coint);
    }
}
