using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = -4f;

    [SerializeField]
    float jumpHeight = 7.5f;

    private Rigidbody2D myRb;

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        myRb.velocity = new Vector2(moveSpeed, myRb.velocity.y);
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
