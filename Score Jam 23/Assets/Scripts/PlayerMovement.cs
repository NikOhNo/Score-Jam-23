using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    float moveSpeed = 5f;
    [SerializeField]
    float fallSpeed = 3f;
    [SerializeField]
    float maxFallSpeed = 12f;
    [SerializeField]
    float fallDelay = 1f;
    [SerializeField] 
    float baseJumpHeight = 7.5f;
    [SerializeField]
    float fallJumpMultiplier = 1.5f;

    [SerializeField]
    Transform leftEdge;
    [SerializeField]
    Transform rightEdge;

    float horizontalInput = 0f;
    float verticalInput = 0f;
    float fallDelayTimeElapsed = 0f;

    Rigidbody2D myRb;
    float facingDirection = 1f;
    Vector3 originalScale;

    private void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        MoveAndFaceDirection();

        Vector3 clampedPos = new Vector3(Mathf.Clamp(transform.position.x, leftEdge.position.x, rightEdge.position.x), transform.position.y, transform.position.z);

        transform.position = clampedPos;
    }

    private void FixedUpdate()
    {
        fallDelayTimeElapsed += Time.deltaTime;
        verticalInput = Input.GetAxis("Vertical");

        if(fallDelayTimeElapsed >= fallDelay)
        {
            myRb.velocity = new Vector2(myRb.velocity.x, Mathf.Clamp(myRb.velocity.y + (fallSpeed * verticalInput), -maxFallSpeed, Mathf.Infinity));
        }
    }

    private void MoveAndFaceDirection()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        myRb.velocity = new Vector2(horizontalInput * moveSpeed, myRb.velocity.y);

        // Update Direction Player is Facing
        if (horizontalInput > 0)
        {
            facingDirection = 1f;
        }
        else if (horizontalInput < 0)
        {
            facingDirection = -1f;
        }
        else if (Mathf.Abs(horizontalInput) < Mathf.Epsilon)
        {
            myRb.velocity = new Vector2((horizontalInput * moveSpeed) + MapScroll.instance.GetScrollSpeed(), myRb.velocity.y);
        }
        transform.localScale = new Vector3(originalScale.x * facingDirection, originalScale.y, originalScale.z);
    }

    public float GetFaceDirection()
    {
        return facingDirection;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool canJump = GetComponentInChildren<JumpChecker>().GetCanJump();
        float jumpHeight = baseJumpHeight;

        if ((collision.gameObject.tag == "Jumpable") && canJump)
        {
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                jumpHeight *= fallJumpMultiplier;
            }
            
            if (collision.gameObject.TryGetComponent<BreakablePlatform>(out BreakablePlatform platform))
            {
                platform.BreakPlatform();
            }

            Jump(jumpHeight);
        }
        else if (collision.collider.gameObject.tag == "Goomba" && canJump)
        {
            Destroy(collision.gameObject);

            Jump(jumpHeight);
        }
    }

    private void Jump(float height)
    {
        myRb.velocity = new Vector2(myRb.velocity.x, height);

        fallDelayTimeElapsed = 0f;
    }
}
