using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private enum MovementState {idle, running, jumping, falling} // each state has an int value, in order, 0 1 2 3
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround; // helps us choose directly from unity editor
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f; // serialized field allows to change in unity editor
    [SerializeField] private float jumpForce = 10f; // serialized field allows to change in unity editor

    [SerializeField] private AudioSource jumpSound; 

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal"); // axis, -1 left, +1 right
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y); // move left or right, better instead of checking > 0 and < 0

        if(Input.GetButtonDown("Jump") && IsGrounded())  //button uses unity project settings (also using alternate keys)
        {    
            jumpSound.Play(); // play the jump sound
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // jump
        }

        UpdateAnimation();

    }

    private void UpdateAnimation()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;  // case for going right
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;  // case for going left
        }
        else
        {
            state = MovementState.idle; // switch back to idle
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state); // set the state to the animator

    }

    private bool IsGrounded() //we verify here if the player is on ground and not in air
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround); // first two, bounds create a hitbox, with .1f under the original hitbox, an offset which verifies if we touch the ground
    }
}
