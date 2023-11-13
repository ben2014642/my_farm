using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodExtensions : MonoBehaviour
{
    public static string RemainingTime(float remainingTime)
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
