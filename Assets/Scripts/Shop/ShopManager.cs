using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameObject itemPre;
    [SerializeField] Transform content;
    [SerializeField] List<ShopModel> shopModel;
    [SerializeField] PlayerModel playerModel;

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

        if (playerModel.GetCoin() >= model.price)
        {
            PetManager.Instance.Spawn(model.idImage);
            playerModel.AddCoin(-model.price);
        } else
        {
            Debug.Log("Bạn dell đủ tiền !");

        }

        /*if (PlayerModel.Instance.GetCoin() >= item.price)
        {
            PetManager.Instance.Spawn(item.idImage);
            PlayerModel.Instance.MinusCoin(item.price);
        }*/
        //PetManager.Instance.Spawn(item.idImage);


    }
}
