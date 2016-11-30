using UnityEngine;
using System.Collections;

public class NpcBehaviour : MonoBehaviour {

    Vector3 origem;
    Vector3 atual;
    public float min,max;

    private float xMax, xMin;

    public float speed;
    Rigidbody2D rb;

    public bool facingRight = true;
    bool andar = true;
        
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>() ;

        origem = transform.position;
        atual = origem;
    }
	
	void FixedUpdate ()
    {
        rb.velocity = new Vector2(speed, 0f);

        xMin = origem.x - min;
        xMax = origem.x + max;

        if (transform.position.x >= xMax && speed > 0)
        {
            speed *= -1;
            Flip();
        }
        else if (transform.position.x <= xMin && speed < 0)
        {
            speed *= -1;
            Flip();
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
