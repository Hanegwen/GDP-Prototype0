using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float cameraOffset;

	// Use this for initialization
	void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            this.gameObject.transform.position = new Vector3(player.transform.position.x + cameraOffset, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
    }
}
