using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ItemSlot : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtQuantity;
    [SerializeField] GameObject iconItem;
    [SerializeField] KhoManager khoManager;
    [SerializeField] ItemSlot thisItem;
    public KhoModel model;

    private void Awake()
    {
        khoManager = GameObject.Find("KhoManager").GetComponent<KhoManager>();
    }
    public void SetInfo()
    {
        txtQuantity.text = $"{model.quantity}";

        iconItem.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/ItemKho/" + model.image);
    }

    public void SetModel(KhoModel model)
    {
        this.model = model;
    }

    public void ClickOnSetDescItem()
    {
        var desc = $"{model.nameItem}: {model.descItem}";
        khoManager.SetDescItem(desc);
        khoManager.SetItemSelected(this);
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
