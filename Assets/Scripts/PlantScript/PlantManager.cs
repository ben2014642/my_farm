using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    [SerializeField] GameObject land;
    [SerializeField] float soLuong;


    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < soLuong; i++)
        {
            Instantiate(land, gameObject.transform);
        }


    }


    
}
