using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float projectileSpeed;
    private float direction;

    private float lifeTime;
    private float timeElapsed;

    private Rigidbody2D myRb;

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveProjectile();

        timeElapsed += Time.deltaTime;
        if(timeElapsed >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Health>().DecreaseHealth();
            ScreenShaker.instance.ShakeCamera(1f, 1f, 0.35f);
            Destroy();
        }
    }

    private void MoveProjectile()
    {
        myRb.velocity = new Vector2(projectileSpeed * direction, 0f);
    }

    private void Destroy()
    {
        Destroy(gameObject, 0.01f);
    }

    public void SetProjectile(float speed, float dir, float time)
    {
        projectileSpeed = speed;
        direction = dir;
        lifeTime = time;
    }

}
