using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    //get handle to rigidbody
    private Rigidbody2D rb;

    //variale for jumpforce
    [SerializeField]
    private float liftForce = 5.0f;

    [SerializeField]
    private LayerMask groundLayer;

    private bool resetJumpNeeded = false;

    // Use this for initialization
    void Start () {
        //assign handle of rigidbody
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
    }

    public void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(move, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, liftForce);
            StartCoroutine(ResetJumpRoutine());
        }
    }

    IEnumerator ResetJumpRoutine()
    {
        resetJumpNeeded = true;
        yield return new WaitForSeconds(0.1f);
        resetJumpNeeded = false;
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 
            0.6f, groundLayer.value);
        if(hit.collider != null)
        {
            if(resetJumpNeeded == false)
                return true;
        }

        return false;
    }
}
