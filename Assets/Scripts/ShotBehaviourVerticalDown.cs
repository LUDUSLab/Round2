using UnityEngine;
using System.Collections;

public class ShotBehaviourVerticalDown : MonoBehaviour
{

    public float speed;

    private bool flipped = false;

    Rigidbody2D rb;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        rb.velocity = new Vector2(0f, -speed);

    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag != "Shot")
            Destroy(gameObject);
        if (coll.gameObject.tag == "Shot")
            rb.transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
    }
}