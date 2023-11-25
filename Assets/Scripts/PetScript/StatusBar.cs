using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    [SerializeField] GameObject healthBar;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI statusText;
    [SerializeField] Image frontHealthBar;

    public void ShowHealthBar(bool isShow)
    {
        healthBar.SetActive(isShow);
    }

    public void SetTime(string timeRemain)
    {
        timerText.text = timeRemain;
    }

    public void SetActiveHealthBar(bool isShow)
    {
        healthBar.SetActive(isShow);
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

    public void SetValueHealthBar(float value)
    {
        frontHealthBar.fillAmount = value;
    }
}