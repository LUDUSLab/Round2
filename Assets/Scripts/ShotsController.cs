using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShotsController : MonoBehaviour
{

    public float spawnRateMax;
    public float spawnRateMin;
    float spawnRate;

    public GameObject shot;

    public Transform aim;

    private bool visivel = false;

    void Start()
    {
        visivel = false;

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        InvokeRepeating("Shoot", 0, spawnRate);
    }

    public void OnBecameVisible()
    {
        visivel = true;
    }

    public void OnBecameInvisible()
    {
        visivel = false;
    }

    void Shoot()
    {
        if (visivel)    Instantiate(shot, aim.position,Quaternion.identity); 
    }
}