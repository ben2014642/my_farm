﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShopManager : PopupManager
{
    [SerializeField] GameObject itemPre;
    [SerializeField] Transform content;
    [SerializeField] List<ShopModel> shopModel;
    [SerializeField] PlayerManager playerManager;

    [SerializeField] Button btnClose;

    private void Awake()
    {
        InitialShopItem();
        btnClose.onClick.AddListener(CloseShop);

    }

    public void InitialShopItem()
    {
        foreach (ShopModel item in shopModel)
        {
            GameObject itemObj = null;
            itemObj = Instantiate(itemPre, content);
            ItemManager getItem = itemObj.GetComponent<ItemManager>();
            getItem.SetModel(item);
            getItem.SetInfo();
            getItem.btnBuy.onClick.AddListener(() => Buy(item));

        }
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }

    public void ShowShop()
    {
        gameObject.SetActive(true);

    }

    public void Buy(ShopModel model)
    {
        //GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        //ItemManager item = ButtonRef.GetComponent<ItemManager>();

        if (playerManager.GetCoin() >= model.price)
        {
            PetManager.Instance.Spawn(model);
            CongTienManager.instance.CreateText(gameObject.transform.position, -model.price);
        } else
        {
            PopupBasic obj = CreatePopup("shop", "Prefabs/Popup");
            obj.SetMessage("Bạn dell đủ tiền !");
        }

        /*if (PlayerModel.Instance.GetCoin() >= item.price)
        {
            PetManager.Instance.Spawn(item.idImage);
            PlayerModel.Instance.MinusCoin(item.price);
        }*/
        //PetManager.Instance.Spawn(item.idImage);


    }
}
