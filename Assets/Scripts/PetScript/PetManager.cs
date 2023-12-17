using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    const string nameFish = "objFish";
    const string nameGa = "objGa";
    const string namePig = "objPig";
    const string nameRabit = "objRabit";
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
        for (int i = 0; i < 1; i++)
        {
            Spawn("objGa");
        }
    }

    public void Spawn(string petName)
    {
        GameObject petObj = null;

        switch (petName)
        {
            case namePig:
                petObj = objPig;
                break;
            case nameRabit:
                petObj = objRabit;
                break;
            case nameGa:
                petObj = objGa;
                break;
            default:
                petObj = objFish;
                break;
        }

        var obj = Instantiate(petObj);
        obj.SetActive(true);

        var petMovement = obj.GetComponent<PetMovement>();
        if (petMovement != null)
        {
            if (petName == "objFish")
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