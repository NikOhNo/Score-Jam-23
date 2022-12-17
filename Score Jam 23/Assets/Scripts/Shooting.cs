using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;

    [SerializeField]
    float projectileVelocity;

    [SerializeField]
    Transform projectileSpawnPoint;

    [SerializeField]
    float projectileLifeTime = 100f;

    [SerializeField]
    float shootDelay;

    public bool canShoot = true;

    public virtual void Shoot(float direction = 1f)
    {
        if (canShoot)
        {
            GameObject newProj = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);
            //projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileVelocity * direction, 0f);
            newProj.GetComponent<Projectile>().SetSpeedAndDirection(projectileVelocity, direction);

            Destroy(newProj, projectileLifeTime);

            StartCoroutine(DelayNextShoot(shootDelay));
        }
    }

    IEnumerator DelayNextShoot(float time)
    {
        canShoot = false;

        yield return new WaitForSeconds(time);

        canShoot = true;
    }
}
