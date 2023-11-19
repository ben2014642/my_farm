using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongTienManager : MonoBehaviour
{
    public static CongTienManager instance;
    [SerializeField] GameObject congTienPrefab;
    
    public void CreateText(Transform position, string text)
    {
        Instantiate(congTienPrefab, position);
    }
}
