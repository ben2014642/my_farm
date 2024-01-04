using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    public static Dictionary<string, List<GameObject>> listPool = new();

    private void Awake()
    {
        Instance = this;
    }

    public static GameObject GetObj(string key, GameObject objInstall, Transform pos = null)
    {
        GameObject obj = null;
        if (listPool.ContainsKey(key))
        {
            foreach (var item in listPool[key])
            {
                if (!item.activeSelf)
                {
                    obj = item;
                }
                break;
            }

            if (obj == null)
            {
                obj = Instantiate(objInstall, pos);
                listPool[key].Add(obj);
            }
        } else
        {
            obj = Instantiate(objInstall);
            listPool.Add(key, new List<GameObject>() { obj });
        }

        return obj;
    }
}
