using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class playerBehaviour : MonoBehaviour {

	public float maxSpeed = 10f;

	Rigidbody2D rb;
	bool facingRight = true;
	float move;

	bool grounded = false;
	bool bittingFloor = false;

	public float bittingJumpForce = 700f;
	public Transform groundCheck;
	public Transform bittingCheck;
	float groundRadius = 0.1f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;

	Animator anim;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
	}


	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		bittingFloor = Physics2D.OverlapCircle(bittingCheck.position, 0.1f, whatIsGround);

		move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs(move));

		rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}

	void Update()
	{
		if ( grounded && Input.GetButtonDown ("Jump")) 
		{
			grounded = false;
			bittingFloor = false;

			rb.AddForce (new Vector2 (0, jumpForce));
		}

		if (bittingFloor && Input.GetButtonDown ("Jump")) 
		{
			bittingFloor = false;

			rb.AddForce (new Vector2 (0, bittingJumpForce));
		}

		if (Input.GetButtonDown("Fire1"))	rb.isKinematic = !rb.isKinematic;
	}


	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Shot")
            Die();

    }
}
