using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThoiGianPhatTrien : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime = 120;
    [SerializeField] public float remainingTimeChoAn;

    [SerializeField] protected GameObject healthBar;
    [SerializeField] protected GameObject statusText;
    [SerializeField] protected List<GameObject> itemCare;

    protected float timeChoAn;

    private void Start()
    {
        statusText.SetActive(false);
        remainingTimeChoAn = timeChoAn;
    }
    private void OnEnable()
    {
        TimerManager.timeDownEvent += TimeDownEvent;
        TimerManager.timeDownEvent += ThoiGianChoAn;
        timerText.text = MethodExtensions.RemainingTime(remainingTime);
    }

    private void OnDisable()
    {
        TimerManager.timeDownEvent -= TimeDownEvent;
        TimerManager.timeDownEvent -= ThoiGianChoAn;
    }


    protected void TimeDownEvent()
    {
        // Nếu pet chưa trưởng thành và không trong tình trạng đói
        if (remainingTime >= 0 && remainingTimeChoAn >= 0)
        {
            timerText.text = MethodExtensions.RemainingTime(remainingTime);
            remainingTime -= 1;

        } else
        {
            if (remainingTime <= 0)
            {
                healthBar.SetActive(false);
                statusText.SetActive(true);

                // Ẩn các chức năng khác khi pet trưởng thành
                for (int i = 0; i < itemCare.Count; i++)
                {
                    itemCare[i].SetActive(false);
                }
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

    }
}
