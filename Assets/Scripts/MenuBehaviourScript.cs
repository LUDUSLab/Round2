using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
 
public class MenuBehaviourScript : MonoBehaviour
{
    Animator anim;
 	float escolha;
 	private bool dificil;
 	private bool centro = true;
 	private bool hard = false;
 	private bool easy = false;
    int delay = 0;

    GameController gc;

    void Start()
    {
        gc = (GameController)FindObjectOfType(typeof(GameController));
        anim = GetComponent<Animator>();
    }

 	void Update()
 	{

        if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("enter"))
        {
            gc.setDificulty(true);
            SceneManager.UnloadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("Stage1");
        }
            /*
 		escolha = Input.GetAxis ("Horizontal");
 		anim.SetBool ("Ligado", hard);
 		if (centro && escolha > 0) {
 			centro = false;
 			hard = true;
 		}
 		if (centro && escolha< 0) {
 			centro = false;
 			easy = true;
 		}
 		if (hard && escolha< 0) {
 			hard = false;
 			easy = true;
 		}
 		if (easy && escolha > 0) {
 			easy = false;
 			hard = true;
 		}
 		if (easy) {
 			if (Input.GetKey (KeyCode.KeypadEnter) || Input.GetKey ("enter")) {
 				dificil = false;
                SceneManager.LoadScene("Stage1");
            }
 		}
 		if (hard) {
 			if (Input.GetKey (KeyCode.KeypadEnter) || Input.GetKey ("enter")) {
 				dificil = true;
 				SceneManager.LoadScene ("Stage1");
 			}
 		}*/
    }
 }