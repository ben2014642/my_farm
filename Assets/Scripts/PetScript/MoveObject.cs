using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] float maxDistance;
    [SerializeField] GameObject MangAn;
    [SerializeField] float speed = 0.4f;

    Animator anim;
    SpriteRenderer spi;

    public float delay = 3;
    public float timer = 0;
    public float currentXPos = 0;
    public float checkFlip;

    public Vector2 waypoint = Vector2.zero;
    void Start()
    {
        anim = GetComponent<Animator>();
        spi = GetComponent<SpriteRenderer>();
        MangAn = GameObject.Find("MangAn");
        currentXPos = transform.position.x;
        if (transform.tag == "Fish")
        {
            maxDistance = 1f;

        }
        
    }

    private void FixedUpdate()
    {

        if (waypoint == Vector2.zero)
        {

            NewDestination(Vector2.zero);

        }
        float distance = Vector2.Distance(transform.position, waypoint);

        if (distance <= 1)
        {
            currentXPos = transform.position.x;
            timer += Time.deltaTime;
            if (timer <= delay)
            {
                checkFlip = 0;
                anim.SetBool("move", false);
                return;
            }
            timer = 0;
            waypoint = Vector2.zero;
        }
        if ((currentXPos != 0 && checkFlip < 2) || MangAn.GetComponent<MangAnManager>().choan)
        {
            Flip();

        }
        StartMove();
    }

    void StartMove ()
    {
        anim.SetBool("move", true);

        transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);



    }

    public void NewDestination(Vector2 target)
    {

        if (target != Vector2.zero)
        {
            
            waypoint = new Vector2(target.x, target.y);

        } else 
        {
            float x = transform.position.x + Random.Range(-maxDistance, maxDistance);
            float y = transform.position.y + Random.Range(-maxDistance, maxDistance);
            waypoint = new Vector2(x, y);
        }

    }

    void Flip()
    {

        if (transform.position.x > currentXPos)
        {
            spi.flipX = true;
        }
        else
        {
            spi.flipX = false;
        }

        checkFlip += 1;

    }
    
    public void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;

    }

}
