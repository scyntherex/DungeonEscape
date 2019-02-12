using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy 
{
    public void Start()
    {
        Attack();
    }

    public override void Update()
    {
        Debug.Log("MossGiant Updating.");
    }
}
