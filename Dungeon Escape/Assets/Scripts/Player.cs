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

    [SerializeField]
    private float moveSpeed = 2.5f;

    //handle player anim
    private PlayerAnimation playerAnim;

    SpriteRenderer playerSprite;

    // Use this for initialization
    void Start () {
        //assign handle of rigidbody
        rb = GetComponent<Rigidbody2D>();
        //assign handle to player anim
        playerAnim = GetComponent<PlayerAnimation>();

        playerSprite = GetComponentInChildren<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
    }

    public void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");

        FlipDirection(move);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, liftForce);
            StartCoroutine(ResetJumpRoutine());
        }

        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        playerAnim.Move(move);
    }

    void FlipDirection(float move)
    {
        //if move > 0, 
        //  face right
        //else
        // face left
        if (move > 0)
            playerSprite.flipX = false;
        else if (move < 0)
            playerSprite.flipX = true;
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
