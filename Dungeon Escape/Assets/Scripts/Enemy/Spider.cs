using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public GameObject acidEffectPrefab;
    public int Health { get; set; }

    //Used for Initialization
    public override void Init()
    {
        base.Init();

        Health = base.health;
    }

    public override void Update()
    {
        
    }

    public void Damage()
    {
        if (isDead == true)
            return;

        Health--;
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

    public override void Movement()
    {
        //sit still     
    }

    public void Attack()
    {
        //instantiate acid effect
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }
}
