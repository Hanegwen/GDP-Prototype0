using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

    PlayerController player;

    public ParticleSystem[] Stars;

    public Vector3[] spawnPositions;

    public bool spawn;

    public Vector3 spawnLocation = new Vector3();

    // Use this for initialization
    void Start ()
    {
        spawn = true;
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        StarDelay();

        if (spawn)
        {
            MakeLocation();
            Spawner();
        }

        
    }


    void MakeLocation()
    {
        int spawn;

        spawn = Random.Range(0, spawnPositions.Length);
        spawnLocation = spawnPositions[spawn];
        
    }


    void Spawner()
    {

        int ranObject;
        ParticleSystem spawnObject;

        ranObject = Random.Range(0, Stars.Length);

        spawnObject = Stars[ranObject];

        Instantiate(spawnObject, player.transform.position + spawnLocation, Quaternion.identity);


        spawn = false;
        StartCoroutine(StarDelay());
    }

    IEnumerator StarDelay()
    {
        yield return new WaitForSeconds(2);
        spawn = true;
    }
}
