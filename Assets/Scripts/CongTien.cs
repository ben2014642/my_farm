using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CongTien : MonoBehaviour
{

    [SerializeField] float speed = 1.5f;
    [SerializeField] float lifeTime;
    public TextMeshProUGUI congTienUI;
    // Start is called before the first frame update

    private void Start()
    {
        StartCoroutine(FadeOut());
    }
    // Update is called once per frame

    void Update()
    {
        MoveObject();
    }

    void MoveObject()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public IEnumerator FadeOut()
    {
        float startAlpha = congTienUI.color.a;
        float rate = 1.0f / lifeTime;
        float progress = 0.0f;

        while (progress < 1.0)
        {
            Color tmp = congTienUI.color;
            tmp.a = Mathf.Lerp(startAlpha, 0, progress);
            congTienUI.color = tmp;

            progress += rate * Time.deltaTime;
            yield return null;

        }
       
        Destroy(gameObject);
       
    }
}
