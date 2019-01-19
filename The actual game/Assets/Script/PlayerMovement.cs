using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Rigidbody2D playerRb;

    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool hasJump;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        speed = 15f;
        jumpForce = 600f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        PlayerControl(horizontal);
        
    }

    void PlayerControl(float horizontal)
    {
        playerRb.velocity = new Vector2(horizontal * speed, playerRb.velocity.y);
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
