using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{ //all this does is destroy the object when it gets out of range
    PlayerController player;
    public AudioSource obstacleAudio;
    public AudioClip crashSound;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        obstacleAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (this.gameObject.transform.position.x - player.transform.position.x < -10)
        {
            Destroy(this.gameObject);
        }
        
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        obstacleAudio.clip = crashSound;
        obstacleAudio.Play();
       
        
    }
}
