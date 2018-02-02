using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public enum PlayerPosition {Top, Center, Bottom };
    public PlayerPosition where;

    public int top = 2;
    public int center = 0;
    public int bottom = -2;

    public float speed = 5;
    public Text distanceText;
    public AudioSource playerAudio;
    public AudioClip jumpSound;
    
     public float distanceval;
    private int lasttag = 0;

    public Text click;


	// Use this for initialization
	void Start ()
    {
        playerAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        distanceval = Mathf.Round(this.gameObject.transform.position.x);
       
        SpeedUp();
        ChangeLane();
        Move();
        distanceText.text = "Distance: " + distanceval.ToString();
        
        if(click != null)
        {
            if(click.fontSize <= 20)
            click.fontSize += 1;
        }
	}

    void ChangeLane()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(click != null)
            {
                Destroy(click);
            }
            playerAudio.clip = jumpSound;
            playerAudio.Play();
            if(where == PlayerPosition.Top)
            {
                where = PlayerPosition.Bottom;
                //this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, Mathf.Lerp(this.gameObject.transform.position.y, bottom, Time.deltaTime));
            }

            else
            {
                where = PlayerPosition.Top;
                //this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, Mathf.Lerp(this.gameObject.transform.position.y, top, Time.deltaTime));
            }
        }
    }

    void Move()
    {
        /*transform.Translate(Vector3.right * Time.deltaTime * speed); */
        //for whatever reason the above string gave a very bizzare glitch, the player would sit in place and drift slowly backwards

        transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);//player is constantly moving forwards

        if (where == PlayerPosition.Top)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, Mathf.Lerp(this.gameObject.transform.position.y, top, Time.deltaTime));
        }

        else
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, Mathf.Lerp(this.gameObject.transform.position.y, bottom, Time.deltaTime));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        distanceText.text = "You crashed, final Distance: " + distanceval.ToString(); //failstate
        //Collision Works
        Destroy(this.gameObject);
    }

    private void SpeedUp()
    { //set the players speed to increase as the game goes on
        if (distanceval >= (lasttag + 200))
        {
            lasttag = Mathf.RoundToInt(distanceval);
            speed = speed + 0.5f;
        }
        else { }
    }
}
