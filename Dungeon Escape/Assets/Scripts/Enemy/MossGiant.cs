using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy 
{
    private Vector3 currentTarget;

    private Animator MossAnim;

    private void Start()
    {
        MossAnim = GetComponentInChildren<Animator>();
    }

    public override void Update()
    {
        //if idle anim active
        //do nothing "return"
        if (MossAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        Movement();
    }

    void Movement()
    {
        float step = speed * Time.deltaTime;
        //if current pos == point A
        //move to point B
        // else if current pos == pos B
        //move to point A
        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position,
            currentTarget, step);
    }
}
