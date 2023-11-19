using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPetEvent : MonoBehaviour
{
    [SerializeField] public bool isShowMenu;
    [SerializeField] GameObject MenuPet;
    [SerializeField] GameObject statusBar;
    [SerializeField] MoveObject moveObject;
    [SerializeField] GameObject MangAn;
    [SerializeField] ThoiGianPhatTrien thoiGianPhatTrien;


    private void Start()
    {
        moveObject = gameObject.GetComponent<MoveObject>();
        MangAn = GameObject.Find("MangAn");
    }

    private void OnEnable()
    {
        PetManager.petAction += ChoAn;
    }

    public void ShowMenu()
    {
        isShowMenu = !isShowMenu;
        if (isShowMenu)
        {
            MenuPet.SetActive(true);
            statusBar.SetActive(false);
        }
        else
        {
            CloseMenu();
        }
        
    }

    public void CloseMenu()
    {
        MenuPet.SetActive(false);
        statusBar.SetActive(true);
    }

    public void ChoAn()
    {
        thoiGianPhatTrien.DaChoAn();
        CloseMenu();
    }
}
