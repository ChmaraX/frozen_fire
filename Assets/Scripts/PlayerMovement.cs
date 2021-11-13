using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PolygonCollider2D coll;
    private SpriteRenderer sprite;
    private Animator animator;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState { idle, running, jumping, falling, dash }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<PolygonCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {

        MovementState state;

        // if moving to right
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        // if moving to left (we prob. don't need this) 
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        // not moving
        else
        {
            state = MovementState.idle;
        }

        // dash-crouch
        if (Input.GetKeyDown("s") && IsGrounded())
        {
            // TODO: make collider take less space
            state = MovementState.dash;
        }

        // jumping and falling has the highest priority so it can overwrite state
        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        } 
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        // checks if box around player is overlapping "jumpableGround" (terrain which has mask Ground)
        // box around player is moved by .2f down so overlap is possible
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .2f, jumpableGround);
    }
}
