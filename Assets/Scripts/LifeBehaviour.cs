using UnityEngine;
using System.Collections;


public class LifeBehaviour : MonoBehaviour {

    playerBehaviour player;
    int hp;

    public int nHeart;

    void Start ()
    {
        player = (playerBehaviour)FindObjectOfType(typeof(playerBehaviour));
        
    }


	void Update ()
    {
        hp = player.getHp();
        if (hp < nHeart) gameObject.SetActive(false);
        else gameObject.SetActive(true);
	}
}
