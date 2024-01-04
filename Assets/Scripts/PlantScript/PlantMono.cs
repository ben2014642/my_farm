using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantMono : PopupManager
{
    [SerializeField] MenuFarm menuFarm;
    [SerializeField] StatusBar statusBar;
    [SerializeField] GameObject menuContent;
    [SerializeField] GameObject itemPlant;
    [SerializeField] GameObject iconPlant;
    [SerializeField] GameObject daTrong;
    [SerializeField] Button btnShowMenu;
    [SerializeField] Button btnThuHoach;
    [SerializeField] List<FarmModel> farmModel;
    protected FarmModel currentPlant;
    protected float timeGrown;
    protected bool isTrong = false;

    void Start()
    {
        btnShowMenu.onClick.AddListener(HandleShowMenu);
        foreach (FarmModel item in farmModel)
        {
            GameObject itemObj = null;
            itemObj = Instantiate(itemPlant, menuContent.transform);
            ItemPlant getItem = itemObj.GetComponent<ItemPlant>();
            currentPlant = item;
            getItem.SetModel(item);
            getItem.SetInfo();
            getItem.btnTrong.onClick.AddListener(() => TrongCay(item));
        }
    }

    // Update is called once per frame
    public void HandleShowMenu()
    {

        if (isTrong)
        {
            daTrong.SetActive(!daTrong.activeSelf);
            return;
        }
        menuFarm.HandleShowMenu();

    }

    public void TimeDownEvent()
    {
        if (timeGrown > 0)
        {
            statusBar.SetTime(MethodExtensions.RemainingTime(timeGrown));
            timeGrown -= 1;
        } else
        {
            DaTruongThanh();
        }

    }

    public void DaTruongThanh()
    {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Plant/" + currentPlant.name);
        btnShowMenu.onClick.RemoveListener(HandleShowMenu);
        btnThuHoach.onClick.AddListener(ThuHoach);
        TimerManager.timeDownEvent -= TimeDownEvent;
    }

    public void ThuHoach()
    {
        if (!isTrong)
        {
            return;
        }
        PopupBasic obj = CreatePopup("shop", "Prefabs/Popup");
        obj.SetMessage("Thu Hoạch Thành Công !");
        SetDatTrong();
    }

    public void SetDatTrong()
    {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Plant/dattrong");
        isTrong = false;
        daTrong.SetActive(false);
    }


    public void TrongCay(FarmModel item)
    {

        if (!isTrong)
        {
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Plant/gieohat");
            iconPlant.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Plant/" + item.name);
            timeGrown = item.timeGrown;
            TimerManager.timeDownEvent += TimeDownEvent;
            HandleShowMenu();
            isTrong = !isTrong;
            currentPlant = item;
            return;
        } else
        {
            PopupBasic obj = CreatePopup("shop", "Prefabs/Popup");
            obj.SetMessage("Ô Này Đã Được Trồng !");
            HandleShowMenu();
        }
    }
}
