﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    //handle for animation
    private Animator playerAnim;

    //reference to swrod anim
    private Animator swordAnim;

	// Use this for initialization
	void Start () {
        //assign handle
        playerAnim = GetComponentInChildren<Animator>();
        swordAnim = transform.GetChild(1).GetComponent<Animator>();
    }
	
	// Update is called once per frame
	public void Move(float move) {
        //anim set float Move , move
        playerAnim.SetFloat("Move", Mathf.Abs(move));
	}

    public void Jumping(bool isJumping)
    {
        playerAnim.SetBool("Jumping", isJumping);
    }

    //attack method
    public void Attacking()
    {
        playerAnim.SetTrigger("Attack");
        //play sword arc anim
        swordAnim.SetTrigger("SwordAnimation");
    }
}
