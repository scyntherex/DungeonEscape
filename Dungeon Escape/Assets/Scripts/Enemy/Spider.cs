using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy {

    private Vector3 target;

    private Animator spiderAnim;

    public void Start()
    {
        spiderAnim = GetComponentInChildren<Animator>();
    }

    public override void Update()
    {
        if (this.spiderAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
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
            target = pointB.position;
            spiderAnim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            target = pointA.position;
            spiderAnim.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position,
            target, step);

        //flip sprite
    }
}
