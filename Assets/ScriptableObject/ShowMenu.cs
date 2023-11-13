using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShowMenu : ScriptableObject
{
    public bool isShowMenuPet = false;

    public void setShowMenu ()
    {
        isShowMenuPet = !isShowMenuPet;
    }
}
