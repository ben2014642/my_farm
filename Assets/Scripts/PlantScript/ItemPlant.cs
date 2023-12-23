using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPlant : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btnTrong;
    FarmModel farmModel;

    public void SetInfo()
    {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Plant/" + farmModel.name);

    }

    public void SetModel(FarmModel model)
    {
        this.farmModel = model;
    }

    
    
}
