using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Component Variables
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Animator sockAnim;
    [SerializeField] BoxCollider2D playerCol;
    [SerializeField] BoxCollider2D pianoCol;
    [SerializeField] GameObject piano;

    //Variables for player movements
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool hasJump;

    public bool isStill;

    // Start is called before the first frame update
    void Start()
    {
        //Assign components to component variables
        playerRb = GetComponent<Rigidbody2D>();
        sockAnim = GetComponent<Animator>();
        playerCol = GetComponent<BoxCollider2D>();
        pianoCol = GetComponent<BoxCollider2D>();
        piano = GameObject.Find("Piano");

        speed = 10f;
        jumpForce = 600f;
        isStill = false;
    }

    // Update is called once per frame
    void Update()
    {
        //The variable horizontal will be 1 on RightArrowKey and -1 on LeftArrowKey
        //horizontal will be 0 when RightArrowKey and LeftArrowKey aren't pressed
        float horizontal = Input.GetAxisRaw("Horizontal");

        //Reference to method
        AtPiano();

        //if isStill is not true then player can move
        if (!isStill)
        {
            //Reference to methods
            PlayerJump();
            PlayerControl(horizontal);
        }
    }

    void PlayerControl(float horizontal)
    {
        //The player's velocity (speed and direction) will change base on the variable horizontal
        playerRb.velocity = new Vector2(horizontal * speed, playerRb.velocity.y);

        //If horizontal is 1 (meaning that RightArrowKey is pressed) then player will face right and vice versa for facing left
        if (horizontal > 0)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
            //Starts moving sock animation
            sockAnim.SetBool("isMoving", true);

        } else if (horizontal < 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
            //Starts moving sock animation
            sockAnim.SetBool("isMoving", true);
        } else
        {
            //Stops moving sock animation
            sockAnim.SetBool("isMoving", false);
        }
    }

    void PlayerJump()
    {
        //UpArrowKey is press and hasJump is false, player will jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && hasJump == false)
        {
            hasJump = true;
            playerRb.AddForce(new Vector2(0f, jumpForce));
        }
    }

    void AtPiano()
    {
        if (playerCol.bounds.Intersects(pianoCol.bounds) && Input.GetKeyDown(KeyCode.Space))
        {
            if (isStill)
            {
                isStill = false;
            }
            else if (!isStill)
            {
                isStill = true;
            }

            playerRb.velocity = new Vector2(0f, 0f);
            transform.position = new Vector2(piano.transform.position.x, transform.position.y);
            sockAnim.SetBool("isMoving", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the player collides with objects with the tag "Stage" such as the platform object, then hasJump will turn false
        //The variable hasJump makes sure that the player isn't able to do more jumps in mid-air
        if (collision.collider.tag == "Stage")
        {
            hasJump = false;
        }
    }
}
