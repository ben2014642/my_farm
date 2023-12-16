using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuPetEvent : MonoBehaviour
{
    [SerializeField] List<GameObject> itemCare;
    [SerializeField] Button btnSell;

    public void ShowMenu()
    {
        gameObject.SetActive(!gameObject.activeSelf);

    }

    public void AddSell(UnityAction action)
    {
        btnSell.onClick.AddListener(action);
    }

    public void hideItemCare()
    {
        for (int i = 0; i < itemCare.Count; i++)
        {
            itemCare[i].SetActive(false);
        }
    }

    public void ClickChoAn()
    {
        MyAction.petAction?.Invoke();
    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
    }
}
