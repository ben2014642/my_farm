using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;
    public static Action timeDownEvent;

    public float mInterval = 1f;
    public float mCountTime = 0;

    private void Update()
    {
        if (timeDownEvent == null)
        {
            return;
        }

        mCountTime += Time.deltaTime;

        if (mCountTime > mInterval)
        {
            mCountTime = 0f;

            timeDownEvent?.Invoke();
        }
    }

}
