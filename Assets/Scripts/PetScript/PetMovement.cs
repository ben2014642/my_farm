using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMovement : MoveObject
{
    private Transform target = null;

    protected override void Start()
    {
        base.Start();
        NewDestination();
        transform.position = waypoint;
        
    }

    public void SetTarget(Transform tf, float newDelay)
    {
        target = tf;
        delay = newDelay;
        
    }

    protected override void FixedUpdate()
    {

        if (timer <= delay)
        {
            anim.SetBool("move", false);
            timer += Time.deltaTime;
            return;
        }

        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) >= 1f)
            {
                Debug.Log("chua den");
                anim.SetBool("move", true);
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                spi.flipX = target.position.x > transform.position.x;
            }
            else
            {
                Debug.Log("da den");

                target = null;
                timer = 0;
                NewDestination();
            } 
        } else
        {
            base.FixedUpdate();
        }
            
    }

    public override void ChangeSpeed(float newSpeed)
    {
        base.ChangeSpeed(newSpeed);
    }
}
