﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OTrungManager : MonoBehaviour
{
    public static OTrungManager instance;
    [SerializeField] Sprite[] otrungSpi;
    [SerializeField] SpriteRenderer spi;
    [SerializeField] int soluong = 0;
    [SerializeField] TextMeshProUGUI soLuongText;
    protected PopupManager popupManager;

    private void Start()
    {
        spi = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Awake()
    {
        popupManager = GameObject.Find("PopupManager").GetComponent<PopupManager>();
        instance = this;
        SetSLTrung();

    }

    public void ThuHoachTrung(int sl)
    {
        soluong += sl;
        SetSLTrung();
        ChangeSprite(1);
    }

    public void SellTrung()
    {

        if (soluong <= 0)
        {
            popupManager.NewPopup("Không có trứng để thu hoạch !");
            return;
        }

        CongTienManager.instance.CreateText(transform.position, soluong * 100);
        soluong = 0;
        SetSLTrung();
        ChangeSprite(0);
    }

    public void ChangeSprite(int value)
    {
        spi.sprite = otrungSpi[value];
    }

    public void SetSLTrung()
    {
        soLuongText.text = $"SL {soluong}/20";
    }
}
