using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopupBasic : MonoBehaviour
{
    protected string message;
    [SerializeField] TextMeshProUGUI txtPopup;
    [SerializeField] Button btnClose;

    public void SetMessage(string message)
    {
        this.message = message;
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }
    public void CreateMessage(string newMessage)
    {
        SetMessage(newMessage);
        txtPopup.text = message;
        btnClose.onClick.AddListener(ClosePopup);
    }

    public void ClosePopup()
    {
        SetActive(false);
    }
}
