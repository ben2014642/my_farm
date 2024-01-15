using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{

    public static PopupManager Instance;
    [SerializeField] GameObject popupPre;
    

    public void NewPopup(string text)
    {
        GameObject createdPopup = GameObject.FindGameObjectWithTag("Popup");
        if (!createdPopup)
        {
            createdPopup = Instantiate(popupPre, transform);
        }
        createdPopup.GetComponent<PopupBasic>().SetMessage(text);
    }

}
