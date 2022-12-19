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

    [SerializeField]
    float shootBuffSpread = 3f;

    public bool canShoot = true;

    public virtual void Shoot(float direction = 1f)
    {
        if (canShoot)
        {
            MakeProjectile(direction, 0f);

            if (FindObjectOfType<EffectHandler>().ShootBoostActive())
            {
                MakeProjectile(direction, shootBuffSpread);
                MakeProjectile(direction, -shootBuffSpread);
            }

            StartCoroutine(DelayNextShoot(shootDelay));
        }
    }

    private void MakeProjectile(float direction, float yVelocity)
    {
        GameObject newProj = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);
        newProj.GetComponent<Projectile>().SetProjectile(projectileVelocity, yVelocity, direction, projectileLifeTime);
        newProj.transform.localScale = new Vector3(direction * projectile.transform.localScale.x, projectile.transform.localScale.y, projectile.transform.localScale.z);
    }

    IEnumerator DelayNextShoot(float time)
    {
        canShoot = false;

        yield return new WaitForSeconds(time);

        canShoot = true;
    }
}
