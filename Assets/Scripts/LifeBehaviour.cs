using UnityEngine;
using System.Collections;


public class LifeBehaviour : MonoBehaviour {

    public playerBehaviour player;
    int hp;

    public int nHeart;

    void Start ()
    {
        
    }


	void Update ()
    {
        hp = player.getHp();
        if (hp >= nHeart)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = 1;
            transform.localScale = theScale;
        }
        if (hp < nHeart)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = 0;
            transform.localScale = theScale;
        }
	}
}