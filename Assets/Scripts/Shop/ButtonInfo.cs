using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    [SerializeField] ShopModel shopModel;
    [SerializeField] GameObject itemPre;
    [SerializeField] Transform content;
    private void Start()
    {
        InitialShopItem();
    }

    public void InitialShopItem()
    {
        foreach (ShopItem item in shopModel.shopItems)
        {
            GameObject itemObj = null;
            itemObj = Instantiate(itemPre, content);

            //set name
            GameObject namePet = itemObj.GetComponent<ItemManager>().namePet;
            namePet.GetComponent<TextMeshProUGUI>().text = $"Name: {item.namePet}";
            //set price
            GameObject priceTxt = itemObj.GetComponent<ItemManager>().priceTxt;
            priceTxt.GetComponent<TextMeshProUGUI>().text = $"Giá: {item.price}";
            //set sell price
            GameObject sellPriceTxt = itemObj.GetComponent<ItemManager>().sellPriceTxt;
            sellPriceTxt.GetComponent<TextMeshProUGUI>().text = $"Giá bán: {item.sellPrice}";
            //set time grown
            GameObject timeGrownTxt = itemObj.GetComponent<ItemManager>().timeGrownTxt;
            timeGrownTxt.GetComponent<TextMeshProUGUI>().text = $"Thời gian lớn: {item.timeGrown}p";
            //set image
            GameObject iconItem = itemObj.GetComponent<ItemManager>().iconItem;
            iconItem.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/"+item.idImage);
        }
    }


}
