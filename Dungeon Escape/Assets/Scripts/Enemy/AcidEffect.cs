using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour {

    private void Start()
    {
        //destroy after 5 sec.
        Destroy(this.gameObject, 5.0f);
    }

    private void Update()
    {
        //move right 3 units/s
        transform.Translate(Vector3.right * 3 * Time.deltaTime);
    }

    //detect player and deal damage via IDamageable interface
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            IDamageable hit = other.GetComponent<IDamageable>();

            if(hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }
}
