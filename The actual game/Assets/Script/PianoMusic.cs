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
    [SerializeField] GameObject dNote;
    [SerializeField] GameObject line;

    //Clips
    public AudioClip dNatural;

    [SerializeField] bool isPlayingPiano;


    // Start is called before the first frame update
    void Start()
    {
        //Assigns components to Component Variables
        playerCol = GetComponent<BoxCollider2D>();
        pianoCol = GetComponent<BoxCollider2D>();
        pianoAudio = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        movementScript = player.GetComponent<PlayerMovement>();
        dNote = GameObject.Find("DNote");
        line = GameObject.Find("Line");
        isPlayingPiano = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Reference to method
        PlayPianoMusic();
        MusicGamePlay();
    }

    void PlayPianoMusic()
    {
        if (playerCol.bounds.Intersects(pianoCol.bounds) && movementScript.isStill)
        {
            isPlayingPiano = true;
        } else
        {
            isPlayingPiano = false;
        }

        //When player is overlapping piano and "a" is pressed
        if (playerCol.bounds.Intersects(pianoCol.bounds) && Input.GetKeyDown("a") && movementScript.isStill)
        {
            pianoAudio.clip = dNatural;
            pianoAudio.Play();
        }
    }

    void MusicGamePlay()
    {
        if (isPlayingPiano)
        {
            if (Input.GetKeyDown("a"))
            {
                float distance = Mathf.Abs(dNote.transform.position.y - line.transform.position.y);
                Debug.Log(distance);

                if ( distance <= 3)
                {
                    Debug.Log("Perfect");
                } else if (distance >= 3)
                {
                    Debug.Log("Bad");
                }
            }
        }
    }
}
