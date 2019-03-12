using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour {

    //handle to spider
    private Spider enemySpider;

    private void Start()
    {
        //assign handle to the spider
        enemySpider = transform.parent.GetComponent<Spider>();
    }

    public void Fire()
    {
        //Tell spider to fire
        Debug.Log("Spider projectile.");
        //use handle to call attack method on spider
        enemySpider.Attack();
    }
}
