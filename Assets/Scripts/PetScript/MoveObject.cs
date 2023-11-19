using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] protected Transform tfMin, tfMax;
    [SerializeField] protected GameObject limitPosition;
    [SerializeField] protected float speed = 0.4f;
    [SerializeField] protected float delay = 5;
    [SerializeField] protected SpriteRenderer spi;
    [SerializeField] protected Animator anim;
    public float timer = 0;

    public bool checkFlip = false;

    public Vector2 waypoint = Vector2.zero;
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        spi = GetComponent<SpriteRenderer>();
        limitPosition = GameObject.Find("LimitPosition");
        NewDestination();
        transform.position = waypoint;


        tfMin = GetComponent<Transform>();

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

        waypoint = new Vector3(Random.Range(tfMin.position.x, tfMax.position.x), Random.Range(tfMin.position.y, tfMax.position.y));
        spi.flipX = waypoint.x > transform.position.x;
    }

    public virtual void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;

    }

}
