using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] Transform tfMin, tfMax;
    [SerializeField] GameObject MangAn;
    [SerializeField] protected float speed = 0.4f;
    [SerializeField] protected float delay = 5;
    [SerializeField] protected SpriteRenderer spi;

    [SerializeField] protected Animator anim;
    //public float delay = 3;
    public float timer = 0;
    //public float currentXPos = 0;

    public bool checkFlip = false;

    public Vector2 waypoint = Vector2.zero;
    void Start()
    {
        anim = GetComponent<Animator>();
        spi = GetComponent<SpriteRenderer>();
        MangAn = GameObject.Find("MangAn");

        NewDestination();
        transform.position = waypoint;
        
    }

    public void SetTf(Transform tMin, Transform tMax)
    {
        tfMin = tMin;
        tfMax = tMax;
    }

    protected virtual void FixedUpdate()
    {
        Debug.Log("BASE");

        if (timer <= delay)
        {
            anim.SetBool("move", false);
            timer += Time.deltaTime;
            return;
        }

        if (Vector3.Distance(waypoint, transform.position) >= 1f)
        {
            StartMove();
            
        } else
        {
            timer = 0;
            NewDestination();
        }
    }

    void StartMove ()
    {

        anim.SetBool("move", true);
        transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
        
    }

    public void NewDestination()
    {

        waypoint = new Vector3(Random.Range(-1, 9), Random.Range(-4, 3));
        spi.flipX = waypoint.x > transform.position.x;
    }

    public virtual void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;

    }

}
