using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class playerBehaviour : MonoBehaviour {

	public float maxSpeed = 10f;

    CircleCollider2D coli;
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

    int hp;
    bool died;
    int scientistCounter = 0;

    public Image sprite;
    public Text x;
    public Text scientistCont;

    Animator anim;

    public GameController gc;

    public GameObject endOfLine;

	void Start () 
	{
        endOfLine.SetActive(false);

        gc = (GameController) FindObjectOfType(typeof(GameController));

        if (gc.getDificulty())
        {
            hp = 1;
            Destroy(scientistCont);
            Destroy(x);
            Destroy(sprite);
        }
        else hp = 3;

        rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
        coli = GetComponent<CircleCollider2D>();

        died = false;
	}


	void FixedUpdate () 
	{
        if (!died)
        {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            bittingFloor = Physics2D.OverlapCircle(bittingCheck.position, 0.1f, whatIsGround);

            if (grounded || bittingFloor) anim.SetBool("OnGround", true);
            else anim.SetBool("OnGround", false);

            move = Input.GetAxis("Horizontal");

            if (!bittingFloor) anim.SetFloat("Speed", Mathf.Abs(move));
            else anim.SetFloat("Speed", 0);

            rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

            if (move > 0 && !facingRight)
                Flip();
            else if (move < 0 && facingRight)
                Flip();
        }
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

		//if (Input.GetButtonDown("Fire1"))	rb.isKinematic = !rb.isKinematic;

        if ((Input.GetKey(KeyCode.KeypadEnter) || Input.GetButtonDown("Submit")) && died)
        {
            SceneManager.UnloadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("HUD");
        }

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
        endOfLine.SetActive(true);
        died = true;
        anim.SetBool("Death", died);
        coli.radius = 0.1755833f;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Shot" && hp == 1)
        {
            Die();
            hp--;
        }
        else if (coll.gameObject.tag == "Shot" && hp != 1) hp--;

        if(coll.gameObject.tag == "Scientist")
        {
            Destroy(coll.gameObject);
            if(scientistCounter < 3 && !gc.getDificulty())
            {
                scientistCounter++;
                scientistCont.text = scientistCounter.ToString();
            }
            else if(scientistCounter == 3)
            {
                hp++;
                scientistCounter = 0;
                scientistCont.text = "0";
                if (hp > 3) hp = 3;
            }
        }
    }

    void OnBecameInvisible()
    {
        hp = 0;
        Die();
    }

    public int getHp()
    {
        return hp;
    }
}
