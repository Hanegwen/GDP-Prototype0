using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerController player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(this.gameObject.transform.position.x - player.transform.position.x < -10)
        {
            Destroy(this.gameObject);
        }
	}
}
