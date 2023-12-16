using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChickenMono : PetMono
{

    protected float delay;
    protected int max = 20, current = 0;

    protected override void OnEnable()
    {
        base.OnEnable();
        TimerManager.timeDownEvent += ThoiGianDeTrung;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        TimerManager.timeDownEvent -= ThoiGianDeTrung;

    }
    public void ThoiGianDeTrung()
    {
        if (petModel.remainingTime > 0) return;

        delay += 1;
        if (delay == petModel.timeDeTrung && current != max)
        {
            current += 1;
            OTrungManager.instance.ThuHoachTrung(1);
            delay = 0;
        }
    }

    public void ThuHoachTrung()
    {
        OTrungManager.instance.ThuHoachTrung(current);
    }

    
}
