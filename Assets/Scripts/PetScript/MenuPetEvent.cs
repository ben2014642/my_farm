using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPetEvent : MonoBehaviour
{
    [SerializeField] public bool isShowMenu;
    [SerializeField] List<GameObject> itemCare;

    public void ShowMenu()
    {
        isShowMenu = !isShowMenu;
        gameObject.SetActive(isShowMenu);
        
    }

    public void hideItemCare()
    {
        for (int i = 0; i < itemCare.Count; i++)
        {
            itemCare[i].SetActive(false);
        }
    }
}
