using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public static PetManager instance { get; set; }
    public static Action petAction;

    private void Awake()
    {
        instance = this;
    }
    public void ChoAn()
    {
        petAction?.Invoke();
    }

}
