using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShooterWeapon : MonoBehaviour
{
    public GameObject bullet;
    float bulletSpeed = 150f;
    float range = 3f;
    public Transform target;

    private void Start()
    {
        InvokeRepeating("GetTarget", 0f, 5f);
    }

    public void GetTarget()
    {
        Enemy closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (var e in FindObjectsOfType<Enemy>())
        {
            float distance = Vector3.Distance(e.transform.position, transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = e;
            }
        }

        if (closest != null && closestDistance < range)
        {
            target = closest.transform;
            Shoot();
        }

        else
            target = null;
    }

    void Shoot()
    {
        GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        Rigidbody rigidbody = instBullet.GetComponent<Rigidbody>();
        Vector3 direction = target.position - transform.position;
        rigidbody.AddForce(direction * bulletSpeed);

        Destroy(instBullet, 1f);
    }
}
