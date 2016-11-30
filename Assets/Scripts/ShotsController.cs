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

    Transform tr;
    float rotation;

    void Start()
    {
        visivel = false;

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        InvokeRepeating("Shoot", 0, spawnRate);

        tr = GetComponent<Transform>();
        rotation = tr.rotation.z;

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
        if (visivel && rotation == 0)    Instantiate(shot, aim.position,Quaternion.identity);
        else if(visivel)    Instantiate(shot, aim.position, Quaternion.Euler(0, 0, 90)); 
    }
}