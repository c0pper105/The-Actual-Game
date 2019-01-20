using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Animator sockAnim;

    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool hasJump;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        sockAnim = GetComponent<Animator>();

        speed = 10f;
        jumpForce = 600f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();

        float horizontal = Input.GetAxisRaw("Horizontal");
        PlayerControl(horizontal);
    }

    void FixedUpdate()
    {
        
        
    }

    void PlayerControl(float horizontal)
    {
        playerRb.velocity = new Vector2(horizontal * speed, playerRb.velocity.y);

        if (horizontal > 0)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
            sockAnim.SetBool("isMoving", true);

        } else if (horizontal < 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
            sockAnim.SetBool("isMoving", true);
        } else
        {
            sockAnim.SetBool("isMoving", false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerRb.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Stage")
        {

        }
    }
}
