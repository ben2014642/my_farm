using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float range;
    [SerializeField] float maxDistance;
    [SerializeField] GameObject MangAn;
    [SerializeField] ShowMenu showMenu;
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
        currentXPos = transform.position.x;
    }

    private void FixedUpdate()
    {

        if (showMenu.isShowMenuPet)
        {
            anim.SetBool("move", false);
            return;
        }
        
        if (waypoint == Vector2.zero)
        {
            NewDestination();
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
        Debug.Log(waypoint);
    }

    void NewDestination()
    {
        if (MangAn.GetComponent<MangAnManager>().choan)
        {
            waypoint = MangAn.transform.position;
        }
        else
        {
            waypoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
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
        Debug.Log("check");

    }

}
