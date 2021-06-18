using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 3.0f;
	public float jumpForce = 100f;
	public float dashSpeed = 6.0f;

	private Rigidbody2D _rigidbody2D;
	
	//for flip
	public bool facingRight = true;
	private float horizontalMovement;
	
	//for jump 
	public Transform groundCheck;
	public float checkRadius;
	private bool isGrounded;
	public LayerMask whatIsGround;

	private int extraJumps = 2;
	private int extraDash = 1;

	//private Animator animator;

	void Start()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		//animator = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		//float characterSpeed = Mathf.Abs(_rigidbody2D.velocity.x);
		//animator.SetFloat("Speed", characterSpeed);
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

		horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;
		_rigidbody2D.velocity = new Vector2(horizontalMovement, _rigidbody2D.velocity.y);
	}

	void Update()
	{
		if (facingRight == false && horizontalMovement > 0)
		{
			Flip();
		}
		else if (facingRight == true && horizontalMovement < 0)
		{
			Flip();
		}

		if (isGrounded == true)
		{
			extraJumps = 2;
			//extraDash = 1;
		}

		if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
		{
			FindObjectOfType<AudioManagerScript>().Play("Jump");
			_rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
			//FindObjectOfType<AudioManagerScript>().Play("Jump_Sound");
			_rigidbody2D.AddForce(new Vector2(0, jumpForce));
			extraJumps--;
		}

		if (Input.GetKeyDown(KeyCode.LeftShift) && extraDash > 0)
		{
			FindObjectOfType<AudioManagerScript>().Play("Dash");
			StartCoroutine("DashMove");
			FindObjectOfType<AudioManagerScript>().Play("Dash");
		}
	}


	IEnumerator DashMove()
	{
		moveSpeed += dashSpeed;
		--extraDash;
		yield return new WaitForSeconds(0.3f);
		moveSpeed -= dashSpeed;
		yield return new WaitForSeconds(0.7f);
		++extraDash;
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}
}
