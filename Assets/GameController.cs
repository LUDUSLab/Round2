using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


    private bool dif;

	void Start ()
    {
        Object.DontDestroyOnLoad(gameObject);
    }

    public void setDificulty(bool dificulty)
    {
        dif = dificulty;
    }

    public bool getDificulty()
    {
        return dif;
    }

}
