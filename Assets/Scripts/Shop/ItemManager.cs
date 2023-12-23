using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI namePetObj;
    [SerializeField] TextMeshProUGUI priceTxtObj;
    [SerializeField] TextMeshProUGUI sellPriceTxtObj;
    [SerializeField] TextMeshProUGUI timeGrownTxtObj;
    [SerializeField] GameObject iconItem;
    public Button btnBuy;
    ShopModel model;

    public void SetInfo()
    {
        namePetObj.text = $"Name: {model.namePet}";
        priceTxtObj.text = $"Giá: {model.price}";
        priceTxtObj.text = $"Giá bán: {model.sellPrice}";
        timeGrownTxtObj.text = $"Thời gian lớn {model.timeGrown}p";
        iconItem.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + model.idImage);
    }

    public void SetModel(ShopModel model)
    {
        this.model = model;
    }


}
