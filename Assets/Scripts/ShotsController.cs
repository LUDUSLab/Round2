using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShotsController : MonoBehaviour {

	public float spawnRate;
	private float currentSpawnRate;

	public int maxShots;
	public GameObject shot;

	public List<GameObject> shots;

	public Transform aim;
	public Transform player;

	//public AudioSource shootAudio;

	void Start () {

		for (int i = 0; i < maxShots; i++) {
			GameObject aux = Instantiate (shot);
			shots.Add (aux);
			aux.SetActive (false);
		}

		currentSpawnRate = spawnRate;
	}


	void Update () {

		currentSpawnRate += Time.deltaTime;
		if(currentSpawnRate> spawnRate)
		{
			currentSpawnRate = 0;
			GameObject aux = null;

			for (int i = 0; i < maxShots; i++) 
			{
				if (shots [i].activeSelf == false) 
				{
					aux = shots [i];
					break;
				}
			}

			if (aux != null) 
			{
				aux.transform.position = aim.position;
				aux.SetActive (true);
	//		shootAudio.Play ();
			}

		}
	}
}