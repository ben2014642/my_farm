using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class KhoManager : MonoBehaviour
{

    [SerializeField] GameObject KhoPanelContent;
    [SerializeField] GameObject itemPre;
    [SerializeField] List<KhoModel> khoModel;
    [SerializeField] TextMeshProUGUI descItem;
    [SerializeField] Button btnCloseKho;
    [SerializeField] Button btnSellItem;
    [SerializeField] ItemSlot currentItemSelected;
    protected PopupManager popupManager;
    private void Awake()
    {
        InitialShopItem();
        popupManager = GameObject.Find("PopupManager").GetComponent<PopupManager>();
        //btnClose.onClick.AddListener(CloseShop);
    }

    public void InitialShopItem()
    {
        foreach (KhoModel item in khoModel)
        {
            GameObject itemObj = null;
            itemObj = Instantiate(itemPre, KhoPanelContent.transform);
            ItemSlot getItem = itemObj.GetComponent<ItemSlot>();
            getItem.SetModel(item);
            getItem.SetInfo();
            //getItem.btnBuy.onClick.AddListener(() => Buy(item));

        }

        btnCloseKho.onClick.AddListener(HandleCloseKho);
        btnSellItem.onClick.AddListener(SellItemKho);
    }


    public void HandleCloseKho()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        SetDescItem("");
        HandleShowBtnSell(false);
    }

    public void SetItemSelected (ItemSlot item)
    {
        currentItemSelected = item;
        HandleShowBtnSell(true);
    }

    public void SetDescItem(string desc)
    {
        descItem.text = desc;

    }

    public void HandleShowBtnSell(bool value)
    {
        btnSellItem.gameObject.SetActive(value);
    }

    public void SellItemKho()
    {
        if (currentItemSelected == null)
        {
            return;
        }
        float price = currentItemSelected.model.priceItem;
        CongTienManager.instance.CreateText(GameObject.Find("CoinText").transform.position, price);
        currentItemSelected.model.quantity -= 1;
        
        if (currentItemSelected.model.quantity <= 0)
        {
            Debug.Log(currentItemSelected.model.quantity);

            currentItemSelected.DestroyItem();
            return;
        }
        currentItemSelected.SetInfo();
    }
}
