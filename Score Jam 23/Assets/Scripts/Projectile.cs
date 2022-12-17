using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float projectileSpeed;
    private float direction;

    private Rigidbody2D myRb;

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        myRb.velocity = new Vector2(projectileSpeed * direction, 0f);
    }

    public void SetSpeedAndDirection(float speed, float dir)
    {
        projectileSpeed = speed;
        direction = dir;
    }
}
