using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PianoMusic : MonoBehaviour
{

    //Component Variables
    [SerializeField] BoxCollider2D playerCol;
    [SerializeField] BoxCollider2D pianoCol;
    [SerializeField] AudioSource pianoAudio;
    [SerializeField] GameObject player;
    [SerializeField] PlayerMovement movementScript;

    //Clips
    public AudioClip dNatural;


    // Start is called before the first frame update
    void Start()
    {
        //Assigns components to Component Variables
        playerCol = GetComponent<BoxCollider2D>();
        pianoCol = GetComponent<BoxCollider2D>();
        pianoAudio = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        movementScript = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {


        //Reference to method
        PlayPianoMusic();
    }

    void PlayPianoMusic()
    {
        //When player is overlapping piano and 
        if (playerCol.bounds.Intersects(pianoCol.bounds) && Input.GetKeyDown("a") && movementScript.isStill)
        {
            pianoAudio.clip = dNatural;
            pianoAudio.Play();
        }
    }
}
