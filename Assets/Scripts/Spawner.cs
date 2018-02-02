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
    public float spawnX;


    // Use this for initialization
    void Start ()
    {
        spawnLocation = new Vector3(20, 0);
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
        if (spawnLocation.x - Player.transform.position.x < distanceForSpawn)
        {
            
            ranY = Random.Range(0, 3);
            if (ranY == 0)
            {
                ranY = pController.bottom;
            }
            if (ranY == 2)
            {
                ranY = pController.center;
            }
            else
            {
                ranY = pController.top;
            }

            spawnLocation.y = ranY;
            spawnLocation.x = Player.transform.position.x + spawnX;


            Spawn();
            

            if (distanceForSpawn > 4) //decrease distance at which objects spawn from players over time
            {
                distanceForSpawn--;
            }
            else if(spawnX > 30)
            {
                spawnX--;
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
