using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMono : PetMono
{
    float delay;

    protected override void OnEnable()
    {
        base.OnEnable();
        TimerManager.timeDownEvent += ThoiGianDeTrung;
        //timerText.text = MethodExtensions.RemainingTime(remainingTime);
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
        if (delay == petModel.timeDeTrung)
        {
            Debug.Log("De trung");
            delay = 0;
        }
    }
}
