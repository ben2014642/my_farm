using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFarm : MonoBehaviour
{
    [SerializeField] Sprite[] trangThaiTrongCay;
    [SerializeField] Image image;
    [SerializeField] GameObject menuUI;
    private void Start()
    {
        
    }
    

    public void HandleShowMenu()
    {
        menuUI.SetActive(!gameObject.activeSelf);
    }

    public void TrongCay()
    {
        image.sprite = trangThaiTrongCay[0];
        Debug.Log("trong cay");

    }
}
