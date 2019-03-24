using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable {

    //variable for amount of diamonds.
    public int Gems;

    //get handle to rigidbody
    private Rigidbody2D rb;

    //variale for jumpforce
    [SerializeField]
    private float liftForce = 5.0f;
    [SerializeField]
    private LayerMask groundLayer;

    private bool isGrounded = false;
    private bool resetJumpNeeded = false;

    [SerializeField]
    private float moveSpeed = 2.5f;

    //handle player anim
    private PlayerAnimation playerAnim;

    SpriteRenderer playerSprite;
    SpriteRenderer swordArcSprite;

    public int Health { get; set; }

    // Use this for initialization
    void Start () {
        //assign handle of rigidbody
        rb = GetComponent<Rigidbody2D>();
        //assign handle to player anim
        playerAnim = GetComponent<PlayerAnimation>();

        playerSprite = GetComponentInChildren<SpriteRenderer>();

        swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();

        Health = 4;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Movement();

        LeftMouseAttack();
    }

    public void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        isGrounded = IsGrounded();

        FlipDirection(move);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, liftForce);
            StartCoroutine(ResetJumpRoutine());
            //tell animator to jump
            playerAnim.Jumping(true);
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
        {
            playerSprite.flipX = false;
            swordArcSprite.flipX = false;
            swordArcSprite.flipY = false;

            Vector3 newPos = swordArcSprite.transform.localPosition;
            newPos.x = 1.01f;
            swordArcSprite.transform.localPosition = newPos;
        } 
        else if (move < 0) 
        {
            playerSprite.flipX = true;
            swordArcSprite.flipX = true;
            swordArcSprite.flipY = true;

            Vector3 newPos = swordArcSprite.transform.localPosition;
            newPos.x = -1.01f;
            swordArcSprite.transform.localPosition = newPos;
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
            1f, groundLayer.value);
        if(hit.collider != null)
        {
            if(resetJumpNeeded == false)
            {
                //set animatorbool to false
                playerAnim.Jumping(false);
                return true;
            }
        }

        return false;
    }

    public void LeftMouseAttack()
    {
        //if left clik && is groudned
        //attack
        /*if (Input.GetKeyDown(KeyCode.Mouse0) && IsGrounded())
        {
            playerAnim.Attacking();
        }*/

        if (Input.GetMouseButtonDown(0) && IsGrounded())
        {
            playerAnim.Attacking();
        }
    }

    public void Damage()
    {
        if(Health < 1)
        {
            return;
        }

        //Debug.Log("Player has been damaged!");
        //remove one health
        Health--;
        //update ui display
        UIManager.UIinstance.UpdateLives(Health);
        //check for death
        if(Health == 0)
        {
            //play death animation
            playerAnim.Dying();
        }


    }

    public void AddGems(int amount)
    {
        Gems += amount;
        UIManager.UIinstance.UpdateGemCount(Gems);
    }
}
