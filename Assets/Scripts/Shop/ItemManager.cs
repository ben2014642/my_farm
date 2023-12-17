using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject namePetObj;
    public GameObject priceTxtObj;
    public GameObject sellPriceTxtObj;
    public GameObject timeGrownTxtObj;
    public GameObject iconItem;

    public int idItem { get; set; }
    public int idImage { get; set; }
    public string namePet { get; set; }
    public float price { get; set; }
    public float sellPrice { get; set; }
    public float timeGrown { get; set; }


}
