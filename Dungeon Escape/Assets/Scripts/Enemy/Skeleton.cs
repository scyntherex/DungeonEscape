using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        //assign health property to enemy health.
        Health = base.health;
    }

    public override void Movement()
    {
        base.Movement();

        Vector3 direction = player.transform.localPosition
            - transform.localPosition;
        Debug.Log("Side: " + direction);

        if (direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = true;
        } else if (direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = false;
        }
    }

    public void Damage()
    {
        //subtract 1 from health
        Health--;

        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        //if health < 1, destroy object
        if (Health < 1)
        {
            Destroy(this.gameObject);
        }
    }

}
