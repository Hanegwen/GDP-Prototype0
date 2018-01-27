using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerPosition {Top, Bottom };
    public PlayerPosition where;

    public int top = 3;
    public int bottom = 0;

    public int speed = 1;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ChangeLane();
        Move();
	}

    void ChangeLane()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(where == PlayerPosition.Top)
            {
                where = PlayerPosition.Bottom;
            }

            else
            {
                where = PlayerPosition.Top;
            }
        }
    }

    void Move()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        if(where == PlayerPosition.Top)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, top);
        }

        else
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, bottom);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Collision Works
        Destroy(this.gameObject);
    }
}
