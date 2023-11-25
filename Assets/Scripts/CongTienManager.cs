using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongTienManager : MonoBehaviour
{
    public static CongTienManager instance;
    [SerializeField] GameObject congTienPrefab;
    int sumcoint = 0;
    private void Awake()
    {
        instance = this;
    }
    public void CreateText(Vector2 position, int coint)
    {
        var obj = Instantiate(congTienPrefab);
        obj.transform.position = position;
        obj.GetComponent<CongTien>().SetText($"+ {coint} Coin");
        sumcoint += coint;
    }
}
