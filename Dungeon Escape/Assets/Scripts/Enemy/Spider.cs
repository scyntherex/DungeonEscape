using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy {

    private Vector3 target;

    public void Start()
    { 
    }

    public override void Update()
    {
        float step = speed * Time.deltaTime;
        //if current pos == point A
        //move to point B
        // else if current pos == pos B
        //move to point A
        if(transform.position == pointA.position)
        {
            target = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            target = pointA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position,
            target, step);

        //play idle when destination reached
        //flip sprite
    }
}
