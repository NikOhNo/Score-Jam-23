using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    float moveSpeed = 5f;
    [SerializeField] 
    float jumpHeight = 7.5f;

    float horizontalInput = 0f;
    Rigidbody2D myRb;

    private void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");;

        myRb.velocity = new Vector2(horizontalInput * moveSpeed, myRb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool canJump = GetComponentInChildren<JumpChecker>().GetCanJump();

        if ((collision.gameObject.tag == "Jumpable") && canJump)
        {
            myRb.velocity = new Vector2(myRb.velocity.x, jumpHeight);
        }
    }
}
