using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

    PlayerController player;
	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(this.gameObject.transform.position.x + 10 < player.gameObject.transform.position.x)
        {
            Destroy(this.gameObject);
        }
	}
}
