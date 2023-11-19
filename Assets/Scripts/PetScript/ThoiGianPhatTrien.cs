using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThoiGianPhatTrien : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime = 120;
    public float timeChoAn = 5;
    [SerializeField] float remainingTimeChoAn;
    [SerializeField] GameObject healthBar;
    [SerializeField] GameObject statusText;
    [SerializeField] GameObject[] itemCare;
    private void Start()
    {
        statusText.SetActive(false);
        remainingTimeChoAn = timeChoAn;
    }

    private void OnEnable()
    {
        TimerManager.timeDownEvent += TimeDownEvent;
        TimerManager.timeDownEvent += ThoiGianChoAn;
    }

    private void OnDisable()
    {
        TimerManager.timeDownEvent -= TimeDownEvent;
        TimerManager.timeDownEvent -= ThoiGianChoAn;
    }


    protected void TimeDownEvent()
    {
        if (remainingTime >= 0)
        {
            timerText.text = MethodExtensions.RemainingTime(remainingTime);
            remainingTime -= 1;

        } else
        {
            healthBar.SetActive(false);
            statusText.SetActive(true);
            for (int i = 0; i < itemCare.Length; i++)
            {
                itemCare[i].SetActive(false);
            }
        }
    }

    protected void ThoiGianChoAn()
    {
        if (remainingTimeChoAn >= 0 && remainingTime >= 0)
        {
            remainingTimeChoAn -= 1;
        } else
        {
            healthBar.SetActive(false);
            statusText.SetActive(true);
            statusText.GetComponent<TextMeshProUGUI>().text = "Đói quá";
        }
    }

    public void DaChoAn()
    {
        remainingTimeChoAn = timeChoAn;
        healthBar.SetActive(true);
        statusText.SetActive(false);
        Debug.Log("Da cho an");

    }
}
