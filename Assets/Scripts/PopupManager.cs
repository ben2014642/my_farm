using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    Dictionary<string, PopupBasic> popupList = new();
    // Start is called before the first frame update
    public PopupBasic CreatePopup(string key, string path, Transform tfParent = null)
    {
        if (popupList.ContainsKey(key))
        {
            popupList[key].SetActive(true);
            return popupList[key];
        }
        var obj = Resources.Load<GameObject>(path);
        var ui = Instantiate(obj).transform.Find("Popup").GetComponent<PopupBasic>();
        if (tfParent != null)
        {
            ui.transform.SetParent(tfParent);
        } 
        popupList.Add(key, ui);
        return ui;
    }
}
