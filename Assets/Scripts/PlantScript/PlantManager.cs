using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    [SerializeField] GameObject land;
    [SerializeField] float soLuong;
    [SerializeField] MenuFarm menuFarm;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < soLuong; i++)
        {
            Instantiate(land, transform.Find("Canvas").transform);
        }
    }

    public void showMenu()
    {
        menuFarm.showMenu();
    }

    public void TrongCay()
    {
        menuFarm.TrongCay();
    }
    
}
