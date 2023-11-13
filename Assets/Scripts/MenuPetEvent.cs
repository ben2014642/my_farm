using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPetEvent : MonoBehaviour
{
    [SerializeField] bool isShowMenu;
    [SerializeField] GameObject MenuPet;
    // Start is called before the first frame update
    void Start()
    {
        MenuPet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowMenu()
    {
        isShowMenu = !isShowMenu;
        if (isShowMenu)
        {
            MenuPet.SetActive(true);
        }
        else
        {
            MenuPet.SetActive(false);

        }

    }
}
