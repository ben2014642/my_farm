using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMono : PopupBasic
{
    [SerializeField] protected MenuPetEvent menuPetEvent;
    [SerializeField] protected PetModel petModel;
    [SerializeField] StatusBar statusBar;
    [SerializeField] GameObject pet;    
    protected PetMovement petMovement;

    public void SetInfo(ShopModel pet)
    {
        petModel.namePet = pet.namePet; 
        petModel.price = pet.price;
        petModel.remainingTime = pet.timeGrown;
        
    }

    protected virtual void OnEnable()
    {
        TimerManager.timeDownEvent += TimeDownEvent;
        TimerManager.timeDownEvent += ThoiGianChoAn;
        MyAction.petAction += DaChoAn;
        //timerText.text = MethodExtensions.RemainingTime(remainingTime);
    }

    protected virtual void OnDisable()
    {
        TimerManager.timeDownEvent -= TimeDownEvent;
        TimerManager.timeDownEvent -= ThoiGianChoAn;
        MyAction.petAction -= DaChoAn;

    }
    private void Start()
    {
        petMovement = gameObject.GetComponent<PetMovement>();
        statusBar.SetTime(MethodExtensions.RemainingTime(petModel.remainingTime));
        petModel.remainingTimeChoAn = petModel.remainingTime / 3;
        menuPetEvent.AddSell(SellPet);
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
            if (petModel.remainingTime <= 0 )
            {
                statusBar.SetActiveStatusText(true);
                statusBar.SetActiveTimerText(false);
                statusBar.SetStatusText("Đã trưởng thành !");
                menuPetEvent.hideItemCare();
                
            }
        }
    }

    public void ShowMenu()
    {
        menuPetEvent.ShowMenu();
        //statusBar.SetActiveHealthBar(!menuPetEvent.gameObject.activeSelf);
        petMovement.ChangeSpeed(menuPetEvent.gameObject.activeSelf ? 0 : 1);
    }

    public void SellPet()
    {
        if (petModel.remainingTime > 0)
        {
            CreatePopup("Thú chưa trưởng thành !");
            return;
        }

        CongTienManager.instance.CreateText(transform.position, petModel.GetCoinSell());
        Destroy(gameObject, .1f);
    }

    protected void ThoiGianChoAn()
    {
        if (petModel.remainingTimeChoAn >= 0 && petModel.remainingTime >= 0)
        {
            petModel.remainingTimeChoAn -= 1;
        }
        else
        {
            if (petModel.remainingTime >= 0)
            {
                statusBar.SetActiveStatusText(true);

                statusBar.SetStatusText("Đói quá");
            }
        }
    }

    public void DaChoAn()
    {
        petMovement.ChangeSpeed(1);
        petModel.remainingTimeChoAn = petModel.remainingTime / 3;
        statusBar.SetActiveStatusText(false);
        menuPetEvent.CloseMenu();
    }
}
