using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMono : MonoBehaviour
{
    [SerializeField] MenuPetEvent menuPetEvent;
    [SerializeField] CongTienManager congTienManager;
    [SerializeField] PetMovement petMovement;
    [SerializeField] string price;
    [SerializeField] float timeChoAn;
    [SerializeField] GameObject pet;

    public static Action petAction;

    private void Start()
    {
        congTienManager = GameObject.Find("==GameManager==").GetComponent<CongTienManager>();
        petMovement = gameObject.GetComponent<PetMovement>();
        
    }

    public void ShowMenu()
    {
        menuPetEvent.ShowMenu();
        if (menuPetEvent.GetComponent<MenuPetEvent>().isShowMenu)
        {
            petMovement.ChangeSpeed(0);
        } else
        {
            petMovement.ChangeSpeed(1);
        }
    }

    public void SellPet()
    {

        StartCoroutine(destroyPet());
    }

    public void ChoAn()
    {
        PetManager.instance.ChoAn();
        if (transform.tag == "Pig")
        {
            Debug.Log("Pigg");
            petMovement.SetTarget(GameObject.Find("MangAn").transform, 3);
        }
        petMovement.ChangeSpeed(1);
    }

    

    public IEnumerator destroyPet()
    {
        congTienManager.CreateText(transform, "+100 coints");
        yield return new WaitForSeconds(1);
        pet.SetActive(false);
    }

    
    
}
