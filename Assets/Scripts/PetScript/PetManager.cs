using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    const int Fish = 2;
    const int Chicken = 3;
    const int Pig = 4;
    const int Rabit = 5;

    protected static PetManager instance;
    public static PetManager Instance { get => instance; }

    public static Action petAction;
    public Transform tfMinGround;
    public Transform tfMaxGround;
    public Transform tfMinWater;
    public Transform tfMaxWater;
    public MangAnManager mangAn;

    [SerializeField] GameObject objPig, objRabit, objGa, objFish;
    private void Awake()
    {
        instance = this;
        /*for (int i = 0; i < 1; i++)
        {
            Spawn("objGa");
        }*/
    }

    public void Spawn(ShopModel pet)
    {
        GameObject petObj = null;

        switch (pet.idImage)
        {
            case Pig:
                petObj = objPig;
                break;
            case Rabit:
                petObj = objRabit;
                break;
            case Chicken:
                petObj = objGa;
                break;
            default:
                petObj = objFish;
                break;
        }

        var obj = Instantiate(petObj);
        obj.SetActive(true);
        obj.GetComponent<PetMono>().SetInfo(pet);
        var petMovement = obj.GetComponent<PetMovement>();
        if (petMovement != null)
        {
            if (pet.idImage == Fish)
            {
                petMovement.SetTf(tfMinWater, tfMaxWater);
            }
            else
            {
                petMovement.SetTf(tfMinGround, tfMaxGround);
            }
        }
    }

}
