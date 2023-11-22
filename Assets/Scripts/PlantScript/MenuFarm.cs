using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFarm : MonoBehaviour
{
    [SerializeField] bool isShowMenu = false;
    [SerializeField] GameObject menuUI;
    [SerializeField] Sprite[] trangThaiTrongCay;
    [SerializeField] Image image;
    private void Start()
    {
        menuUI.SetActive(false);
        image = GetComponent<Image>();
    }
    public void showMenu()
    {
        isShowMenu = !isShowMenu;
        if (isShowMenu)
        {
            menuUI.SetActive(true);
        } else
        {
            menuUI.SetActive(false);
        }

    }

    public void TrongCay()
    {
        image.sprite = trangThaiTrongCay[0];
        showMenu();
        Debug.Log("trong cay");

    }
}
