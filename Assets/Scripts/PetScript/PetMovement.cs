using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMovement : MoveObject
{
    private Transform target = null;

    protected override void Start()
    {
        base.Start();
        Transform tfMinGround = limitPosition.transform.Find("TfMinGround").GetComponent<Transform>();
        Transform tfMaxGround = limitPosition.transform.Find("TfMaxGround").GetComponent<Transform>();
        Transform tfMinWater = limitPosition.transform.Find("TfMinWater").GetComponent<Transform>();
        Transform tfMaxWater = limitPosition.transform.Find("TfMaxWater").GetComponent<Transform>();
        NewDestination();
        transform.position = waypoint;

        if (!transform.CompareTag("Fish"))
        {
            base.SetTf(tfMinGround, tfMaxGround);
        }
        else
        {
            base.SetTf(limitPosition.transform.Find("TfMinWater").transform, limitPosition.transform.Find("TfMaxWater").transform);
        }
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
