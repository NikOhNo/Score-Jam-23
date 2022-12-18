using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : Shooting
{
    private void Update()
    { 
        if (Mathf.Abs(Input.GetAxisRaw("Fire1")) >= Mathf.Epsilon && canShoot)
        {
            Shoot();
        }
    }
    public override void Shoot(float direction = 1)
    {
        direction = FindObjectOfType<PlayerMovement>().GetFaceDirection();
        base.Shoot(direction);

        GetComponent<Animator>().SetBool("Shoot", true);
        GetComponent<Animator>().SetTrigger("Shoot Trig");
    }

    public void EndShootAnim()
    {
        GetComponent<Animator>().SetBool("Shoot", false);
    }
}
