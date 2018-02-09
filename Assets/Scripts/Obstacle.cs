using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{ //all this does is destroy the object when it gets out of range
    PlayerController player;
    public AudioSource obstacleAudio;
    public AudioClip crashSound;

    public enum enemyState {still, moving, explosive };
    private BoxCollider2D myBoxCollider;
    public Sprite splode;
    public enemyState ObstacleType;
    private SpriteRenderer currentrenderer;
    //used for explosives
    public float eRadius;
    public float eStart;
    Vector3 maxSize;
    //used for moving
    public float mBounce;
    public float mSpeed;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        obstacleAudio = GetComponent<AudioSource>();
        currentrenderer = GetComponent<SpriteRenderer>();
        myBoxCollider = GetComponent<BoxCollider2D>();

        maxSize = new Vector3(eRadius, eRadius, 1);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //moving enemies lerping between lanes
        if (ObstacleType == enemyState.moving)
        {
            this.gameObject.transform.position = Vector3.Lerp(new Vector3(this.gameObject.transform.position.x, 2, 0), new Vector3(this.gameObject.transform.position.x, -2, 0), Mathf.PingPong(Time.time * mBounce, 1.0f));
            transform.Translate(Vector3.left * Time.deltaTime * mSpeed, Space.World);
        }

        //enemies expanding
        if (ObstacleType == enemyState.explosive)
        {
            if (this.gameObject.transform.position.x - player.transform.position.x <= eStart)
            {
                if (currentrenderer.sprite != splode) //changes sprite on orange star to be more reddish while exploding
                {
                    currentrenderer.sprite = splode;
                }
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
