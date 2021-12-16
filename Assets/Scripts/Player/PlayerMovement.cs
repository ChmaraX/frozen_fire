using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // TODO: separate projectile from PlayerMovement
    // create general Character controlls class
    // which includes movements, projectile etc.
    public FireProjectileBehaviour fireProjectile;
    public IceProjectileBehaviour iceProjectile;

    private float dirX = 1.0f;
    [SerializeField] public float moveSpeed = 7f;

    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float crouchForce = 14f;

    private Vector2 standingSize;
    private Vector2 standingOffset;

    private bool isCrouching;
    [SerializeField] private Vector2 crouchingSize;
    [SerializeField] private Vector2 crouchingOffset;

    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState { idle, running, jumping, falling, crouching }

    public Inventory inventory;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        standingSize = coll.size;
        standingOffset = coll.offset;

        crouchingSize = new Vector2(standingSize.x, standingSize.y * 0.5f);
        crouchingOffset = new Vector2(crouchingOffset.x, -1);

        inventory.ItemUsed += Inventory_ItemUsed;

    }

    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        IInventoryItem item = e.Item;
        Debug.Log(item.Name + "used");

        // Projectiles are depended on player position thats why they are here
        switch (item.Name)
        {
            case "Fireball":
                Instantiate(fireProjectile, new Vector3(transform.position.x + 1, transform.position.y, -1), transform.rotation);
                break;
            case "Iceball":
                Instantiate(iceProjectile, new Vector3(transform.position.x + 1, transform.position.y, -1), transform.rotation);
                break;
            default: break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        // movement possible on ground
        if (IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }

            // crouching
            if (Input.GetButtonDown("Crouch"))
            {
                Crouch();
            }

            // stop crouching
            if (Input.GetButtonUp("Crouch"))
            {
                StopCrouch();
            }
        }
        // movement possible in air
        else
        {
            // falling down faster
            if (Input.GetButtonDown("Crouch"))
            {
                Down();
            }

            // prevent crouching in air
            if (Input.GetButtonDown("Jump"))
            {
                StopCrouch();
            }
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        state = MovementState.running;
        // if moving to right
        if (dirX > 0f)
        {
            // state = MovementState.running;
            spriteRenderer.flipX = false;
        }
        // if moving to left (we prob. don't need this) 
        else if (dirX < 0f)
        {
            // state = MovementState.running;
            spriteRenderer.flipX = true;
        }

        // slide-crouch
        if (isCrouching)
        {
            state = MovementState.crouching;
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

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void Down()
    {
        rb.velocity = new Vector2(rb.velocity.x, -crouchForce);
    }

    private void Crouch()
    {
        isCrouching = true;
        coll.size = crouchingSize;
        coll.offset = crouchingOffset;
    }

    private void StopCrouch()
    {
        isCrouching = false;
        coll.size = standingSize;
        coll.offset = standingOffset;
    }
}
