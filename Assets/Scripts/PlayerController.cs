using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	private bool doubleJumped;

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D body = GetComponent<Rigidbody2D> ();

		if (grounded) {
			doubleJumped = false;
		}
	
		if (Input.GetKeyDown(KeyCode.Space) && grounded) {
			Jump (body);
		}
		if (Input.GetKeyDown (KeyCode.Space) && !doubleJumped && !grounded) {
			Jump (body);
			doubleJumped = true;
		}

		if (Input.GetKey(KeyCode.D)) {
			body.velocity = new Vector2(moveSpeed, body.velocity.y);
		}
		if (Input.GetKey(KeyCode.A)) {
			body.velocity = new Vector2(-moveSpeed, body.velocity.y);
		}

	}

	public void Jump(Rigidbody2D body) {
		body.velocity = new Vector2(body.velocity.x, jumpHeight);
	}
}
