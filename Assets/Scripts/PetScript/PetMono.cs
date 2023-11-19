using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMono : MonoBehaviour
{
    [SerializeField] MenuPetEvent menuPetEvent;
    [SerializeField] CongTienManager congTienManager;
    [SerializeField] MoveObject moveObject;
    [SerializeField] string price;
    [SerializeField] float timeChoAn;
    [SerializeField] GameObject pet;

    public static Action petAction;

    private void Start()
    {
        congTienManager = GameObject.Find("==GameManager==").GetComponent<CongTienManager>();
        moveObject = gameObject.GetComponent<MoveObject>();
        
    }

    public void ShowMenu()
    {
        menuPetEvent.ShowMenu();
    }

    public void SellPet()
    {

        StartCoroutine(destroyPet());
    }

    public void ChoAn()
    {
        PetManager.instance.ChoAn();
    }

    

    public IEnumerator destroyPet()
    {
        congTienManager.CreateText(transform, "+100 coints");
        yield return new WaitForSeconds(1);
        pet.SetActive(false);
    }

    
    
}
