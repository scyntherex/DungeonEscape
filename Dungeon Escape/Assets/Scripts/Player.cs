using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    //get handle to rigidbody
    private Rigidbody2D rb;


    //private bool moving = false;

	// Use this for initialization
	void Start () {
        //assign handle of rigidbody
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Horizontal inputs for left/right
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        //current velocity = 
        //new velocity (horizontal input, current velocity.y);
        rb.velocity = new Vector2(horizontalInput, rb.velocity.y);
    }
}
