using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    //Used for Initialization
    public override void Init()
    {
        base.Init();

        Health = base.health;
    }

    public override void Movement()
    {
        base.Movement();
    }

    public void Damage()
    {
        if (isDead == true)
            return;

        //subtract 1 from health
        Health--;

        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        //if health < 1, destroy object
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");

            //spawn diamond
            GameObject diamond = Instantiate(diamondPrefab, transform.position, 
                Quaternion.identity);
            //change value of diamond to gem count equivalent
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }
}
