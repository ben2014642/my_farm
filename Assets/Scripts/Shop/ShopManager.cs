using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    [SerializeField] ShopModel shopModel;
    [SerializeField] GameObject itemPre;
    [SerializeField] Transform content;

    [SerializeField] Button btnClose;
    private void Awake()
    {
        InitialShopItem();
        btnClose.onClick.AddListener(CloseShop);

    }

    public void InitialShopItem()
    {
        foreach (ShopItem item in shopModel.shopItems)
        {
            GameObject itemObj = null;
            itemObj = Instantiate(itemPre, content);
            ItemManager getItem = itemObj.GetComponent<ItemManager>();

            //set id
            getItem.idItem = item.idItem;

            //set name
            GameObject namePet = getItem.namePetObj;
            namePet.GetComponent<TextMeshProUGUI>().text = $"Name: {item.namePet}";
            getItem.namePet = item.namePet;

            //set price
            GameObject priceTxt = getItem.priceTxtObj;
            priceTxt.GetComponent<TextMeshProUGUI>().text = $"Giá: {item.price}";
            getItem.price = item.price;

            //set sell price
            GameObject sellPriceTxt = getItem.sellPriceTxtObj;
            sellPriceTxt.GetComponent<TextMeshProUGUI>().text = $"Giá bán: {item.sellPrice}";
            getItem.sellPrice = item.sellPrice;

            //set time grown
            GameObject timeGrownTxt = itemObj.GetComponent<ItemManager>().timeGrownTxtObj;
            timeGrownTxt.GetComponent<TextMeshProUGUI>().text = $"Thời gian lớn: {item.timeGrown}p";
            getItem.timeGrown = item.timeGrown;

            //set image
            GameObject iconItem = itemObj.GetComponent<ItemManager>().iconItem;
            iconItem.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/"+item.idImage);
            getItem.idImage = item.idImage;
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

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        ItemManager item = ButtonRef.GetComponent<ItemManager>();

        /*if (playerModel.GetComponent<PlayerModel>().GetCoin() >= item.price)
        {
            PetManager.Instance.Spawn(item.idImage);
            playerModel.GetComponent<PlayerModel>().MinusCoin(item.price);
        }*/
        PetManager.Instance.Spawn(item.idImage);


    }
}
