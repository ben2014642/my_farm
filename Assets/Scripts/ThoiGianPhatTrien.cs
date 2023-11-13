using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThoiGianPhatTrien : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime = 120;

    private void OnEnable()
    {
        TimerManager.timeDownEvent += TimeDownEvent;
    }

    private void OnDisable()
    {
        TimerManager.timeDownEvent -= TimeDownEvent;
    }


    protected void TimeDownEvent()
    {
        if (remainingTime >= 0)
        {
            timerText.text = MethodExtensions.RemainingTime(remainingTime);
            remainingTime -= 1;
            Debug.Log("Remaining time: " + remainingTime);

        }
    }
}
