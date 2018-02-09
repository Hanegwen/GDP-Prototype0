using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public AudioSource audio1; //Main
    
    public AudioSource audio2;

    public AudioClip backgroundBase;

    public AudioClip backgroundDrums;

    public AudioClip backgroundTop;

    public AudioClip backgroundCenter;

    public AudioClip backgroundBottom;


    PlayerController player;
	// Use this for initialization
	void Start ()
    {
        Background();
        player = FindObjectOfType<PlayerController>();
        audio2.clip = backgroundBase;
        audio2.Play();
	}
	
	// Update is called once per frame
	void Update ()
    {
        AdjustBackground();
        ChangeMusic();
	}

    void Background()
    {
        audio1.clip = backgroundDrums;
        audio1.Play();
        audio1.loop = true;

    }

    void AdjustBackground()
    {
        
        if (audio1.time > 2 && audio1.clip == backgroundDrums)
        {
            audio1.Play();
            audio1.clip = backgroundBase;
        }

        if (audio1.time > 2 && audio1.clip == backgroundBase)
        {
            
            audio1.Play();
            audio1.clip = backgroundDrums;
        }
    }

    void ChangeMusic()
    {
        if(player.where == PlayerController.PlayerPosition.Bottom)
        {
            if (!audio2.isPlaying)
            {
                audio2.clip = backgroundBottom;
                audio2.Play();
            }
        }

        if(player.where == PlayerController.PlayerPosition.Center)
        {
            if (!audio2.isPlaying)
            {
                audio2.clip = backgroundCenter;
                audio2.Play();
            }
        }

        if(player.where == PlayerController.PlayerPosition.Top)
        {
            if (!audio2.isPlaying)
            {
                audio2.clip = backgroundTop;
                audio2.Play();
            }
        }
    }
}
