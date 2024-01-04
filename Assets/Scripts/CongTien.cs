using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CongTien : MonoBehaviour
{

    public TextMeshProUGUI congTienUI;
    // Start is called before the first frame update

    public void HiddenObj()
    {
        gameObject.SetActive(false);
    }

    internal void SetText(string value)
    {
        congTienUI.text = value;
    }
}
