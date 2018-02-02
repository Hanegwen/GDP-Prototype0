using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

    PlayerController player;

    public ParticleSystem[] Stars;

    public bool spawn;

	// Use this for initialization
	void Start ()
    {
        spawn = true;
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        StarDelay();

        if (spawn)
        {
            Instantiate(Stars[0], new Vector3 (player.gameObject.transform.position.x - 2, player.gameObject.transform.position.y), Quaternion.identity);
            Instantiate(Stars[0], new Vector3(player.gameObject.transform.position.x + 7, 3.2f), Quaternion.identity);
            spawn = false;
            StartCoroutine(StarDelay());
        }

        
    }

    IEnumerator StarDelay()
    {
        yield return new WaitForSeconds(3);
        spawn = true;
    }
}
