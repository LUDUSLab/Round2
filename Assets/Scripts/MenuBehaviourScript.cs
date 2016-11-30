using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
 
public class MenuBehaviourScript : MonoBehaviour
{
    public FacilBehaviour facil;
    public InsanoBehaviour insano;

 	float escolha;
 	private bool dificil = false;
    GameController gc;

    void Start()
    {
        gc = (GameController)FindObjectOfType(typeof(GameController));   
    }

 	void Update()
 	{
        facil.anim.SetBool("FacilSelected", dificil);
        insano.anim.SetBool("InsaneSelected", dificil);

        escolha = Input.GetAxis ("Horizontal");


        if (escolha > 0 && !dificil)
        {
            dificil = true;
        }
        if (escolha < 0 && dificil)
        {
            dificil = false;
        }

        if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetButtonDown("Submit"))
        {
            gc.setDificulty(dificil);
            SceneManager.UnloadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("Stage1");
        }
    }
}