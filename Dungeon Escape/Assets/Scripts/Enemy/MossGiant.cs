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
    }

    public void Damage()
    {
    }
}
