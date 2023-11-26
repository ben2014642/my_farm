using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMono : PetMono
{

    protected override void OnEnable()
    {
        base.OnEnable();
        MyAction.petAction += SetTargetToMangAn;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        MyAction.petAction -= SetTargetToMangAn;
    }

    void SetTargetToMangAn()
    {
        petMovement.SetTarget(PetManager.Instance.mangAn.transform, 3);
    }
}
