using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopupBasic : MonoBehaviour
{
    protected string message;
    [SerializeField] GameObject popupPre;

    public void SetMessage(string message)
    {
        this.message = message;
    }

    public void CreatePopup(string newMessage)
    {
        SetMessage(newMessage);
        var obj = Instantiate(popupPre);
        obj.transform.Find("Message").GetComponent<TextMeshProUGUI>().text = message;
        Button closePopup = obj.transform.Find("BtnClose").GetComponent<Button>();
        closePopup.onClick.AddListener(ClosePopup);
    }

    public void ClosePopup()
    {
        Destroy(GameObject.FindGameObjectWithTag("Popup"), .2f);
    }
}
