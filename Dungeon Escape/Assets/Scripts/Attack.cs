using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    //variable to determine if the damage function is called
    private bool canAttack = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Hit: " + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if(hit != null)
        {
            //if can attack
            if(canAttack == true)
            {
                hit.Damage();
                canAttack = false;
                //set can attack variable false
                StartCoroutine(ResetAttackRoutine());
            }
        }
    }

    //coroutine to reset variable after 0.5f;
    IEnumerator ResetAttackRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }
}
