using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{ //all this does is destroy the object when it gets out of range
    PlayerController player;
    public AudioSource obstacleAudio;
    public AudioClip crashSound;

    public enum enemyState {still, moving, explosive };

    public enemyState ObstacleType;

    //used for explosives
    Vector3 maxSize = new Vector3(2, 2, 1);

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        obstacleAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //moving enemies lerping between lanes
        if (ObstacleType == enemyState.moving)
        {
            this.gameObject.transform.position = Vector3.Lerp(new Vector3(this.gameObject.transform.position.x, 2, 0), new Vector3(this.gameObject.transform.position.x, -2, 0), Mathf.PingPong(Time.time * 0.5f, 1.0f));

        }

        //enemies expanding
        if (ObstacleType == enemyState.explosive)
        {
            if (this.gameObject.transform.position.x - player.transform.position.x <= 1.5)
            {
                if (this.gameObject.transform.localScale != maxSize)
                {
                    this.gameObject.transform.localScale += new Vector3(0.05f, 0.05f, 0);
                }
            }                     
                        
        }        
        
        //destroy object on passing out of view
        if (player != null)
        {
            if (this.gameObject.transform.position.x - player.transform.position.x < -10)
            {
                Destroy(this.gameObject);
            }
        }


        
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        obstacleAudio.clip = crashSound;
        obstacleAudio.Play();
       
        
    }
}
