using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopupBasic : MonoBehaviour
{
    //public static PopupBasic Instance;
    //protected string message;
    //[SerializeField] GameObject popupPre;
    [SerializeField] TextMeshProUGUI txtPopup;
    [SerializeField] Button btnClosePopup;

    private void Awake()
    {
        btnClosePopup.onClick.AddListener(ClosePopup);
    }

    public void SetMessage(string message)
    {
        txtPopup.text = message;
    }

    public void ClosePopup()
    {
        Destroy(GameObject.FindGameObjectWithTag("Popup"), .2f);
    }
}
