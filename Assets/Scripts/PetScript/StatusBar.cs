using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI statusText;

    public void SetTime(string timeRemain)
    {
        timerText.text = timeRemain;
    }

    public void SetActiveTimerText(bool isShow)
    {
        timerText.enabled = isShow;
    }

    public void SetStatusText(string text)
    {
        statusText.text = text;
    }

    public void SetActiveStatusText(bool isShow)
    {
        statusText.gameObject.SetActive(isShow);
    }

}
