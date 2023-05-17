using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rigidBody;
	private float moveX = 0f;
	private SpriteRenderer flip;
	public float moveSpeed = 7f;
	public float jumpForce = 14f;

	private BoxCollider2D coll;
	public LayerMask ground;

	private Animator anim;

	public AudioSource jumpSound;

	private enum MovementState
	{
		idle, running, jumping, falling
	}

	// Start is called before the first frame update
	void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		flip = GetComponent<SpriteRenderer>();
		coll = GetComponent<BoxCollider2D>();
	}

    // Update is called once per frame
    void Update()
    {
        // перемещение по горизонтали
        moveX = Input.GetAxisRaw("Horizontal");
		rigidBody.velocity = new Vector2(moveX * moveSpeed, rigidBody.velocity.y);

        // прыгаем
		if (Input.GetKeyDown("space") && IsGrounded())
        {
			jumpSound.Play();
            // velocity - скорость персонажа
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce); // движение прыжка по оси y
        }

        UpdateAnimationState();

	}

    private void UpdateAnimationState()
    {
		MovementState state;

		if (moveX > 0f)
		{
			state = MovementState.running;
			flip.flipX = false;
		}
		else if (moveX < 0f)
		{
			state = MovementState.running;
			flip.flipX = true;
		}
		else
		{
			state = MovementState.idle;
		}

		// скорость никогда не равна 0, поэтому .1f
		if (rigidBody.velocity.y > .1f)
		{
			state = MovementState.jumping;
		} 
		else if (rigidBody.velocity.y < -.1f)
		{
			state = MovementState.falling;
		}

		// берем номер элемента в енуме, не стринг
		anim.SetInteger("movementState", (int) state);
	}

	private bool IsGrounded()
	{
		return Physics2D.BoxCast(coll.bounds.center,
								 coll.bounds.size, 
								 0f, 
								 Vector2.down, 
								 .1f, 
								 ground);

	}
}
