using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMono : MonoBehaviour
{
    [SerializeField] MenuPetEvent menuPetEvent;
    [SerializeField] StatusBar statusBar;
    [SerializeField] PetModel petModel;
    [SerializeField] GameObject pet;    

    CongTienManager congTienManager;
    PetMovement petMovement;

    protected static Action petAction;

    private void OnEnable()
    {
        TimerManager.timeDownEvent += TimeDownEvent;
        TimerManager.timeDownEvent += ThoiGianChoAn;
        petAction += DaChoAn;
        //timerText.text = MethodExtensions.RemainingTime(remainingTime);
    }

    private void OnDisable()
    {
        TimerManager.timeDownEvent -= TimeDownEvent;
        TimerManager.timeDownEvent -= ThoiGianChoAn;
        petAction -= DaChoAn;

    }
    private void Start()
    {
        congTienManager = GameObject.Find("==GameManager==").GetComponent<CongTienManager>();
        petMovement = gameObject.GetComponent<PetMovement>();
        statusBar.SetTime(MethodExtensions.RemainingTime(petModel.remainingTime));
        petModel.remainingTimeChoAn = petModel.timeChoAn;
    }

    protected void TimeDownEvent()
    {
        // Nếu pet chưa trưởng thành và không trong tình trạng đói
        if (petModel.remainingTime >= 0 && petModel.remainingTimeChoAn >= 0)
        {

            statusBar.SetTime(MethodExtensions.RemainingTime(petModel.remainingTime));
            petModel.remainingTime -= 1;

        }
        else
        {
            if (petModel.remainingTime <= 0)
            {
                statusBar.SetActiveHealthBar(false);
                statusBar.SetActiveTimerText(false);
                statusBar.SetStatusText("Đã trưởng thành !");
                // Ẩn các chức năng khác khi pet trưởng thành
                menuPetEvent.hideItemCare();
            }
        }
    }

    public void ShowMenu()
    {
        menuPetEvent.ShowMenu();
        statusBar.SetActiveHealthBar(!menuPetEvent.isShowMenu);
        petMovement.ChangeSpeed(menuPetEvent.isShowMenu ? 0 : 1);
    }

    public void SellPet()
    {

        StartCoroutine(destroyPet());

    }

    public void ChoAn()
    {

        PetManager.Instance.ChoAn();
        if (transform.tag == "Pig")
        {
            petMovement.SetTarget(GameObject.Find("MangAn").transform, 3);
        }
        petMovement.ChangeSpeed(1);

        menuPetEvent.ShowMenu();
        petAction?.Invoke();
    }

    

    public IEnumerator destroyPet()
    {
        congTienManager.CreateText(transform, "+100 coints");
        yield return new WaitForSeconds(1);
        Destroy(pet);
    }


    protected void ThoiGianChoAn()
    {
        if (petModel.remainingTimeChoAn >= 0 && petModel.remainingTime >= 0)
        {
            petModel.remainingTimeChoAn -= 1;
        }
        else
        {
            statusBar.SetActiveHealthBar(false);
            statusBar.SetStatusText("Đói quá");
        }
    }

    public void DaChoAn()
    {
        petModel.remainingTimeChoAn = petModel.timeChoAn;
        statusBar.SetActiveHealthBar(true);
        statusBar.SetActiveStatusText(false);

    }
}
