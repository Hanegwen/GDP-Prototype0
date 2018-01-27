using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
 
{
    public PlayerController pController;
    public GameObject Player;

    public GameObject[] obstacles;

    Vector3 spawnLocation;


    public float distanceForSpawn; //higher == easier

    // Use this for initialization
    void Start ()
    {
        pController = GameObject.FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Player != null)
        {
            CheckLocation();
        }
        
	}

    void CheckLocation()
    {
        int ranY;
        if(spawnLocation.x - Player.transform.position.x < distanceForSpawn)
        {
            


            ranY = Random.Range(0, 2);
            if(ranY == 0)
            {
                ranY = pController.bottom;
            }
            else
            {
                ranY = pController.top;
            }

            spawnLocation.y = ranY;

            Spawn();
            spawnLocation.x += 20;

            if (distanceForSpawn > 2)
            {
                distanceForSpawn--;
            }
        }
    }

    void Spawn()
    {
        int ranObject;
        GameObject spawnObject;

        ranObject = Random.Range(0, obstacles.Length);

        spawnObject = obstacles[ranObject];

        Instantiate(spawnObject, spawnLocation, Quaternion.identity);
    }
}
