﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretWeapon : MonoBehaviour
{
    public GameObject bullet;
    float bulletSpeed = 800f;
    float range = 5f;
    public Transform target;

    private void Start()
    {
        InvokeRepeating("GetTarget", 0f, 2f);
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
        rigidbody.AddForce(Vector3.forward * bulletSpeed);

        Destroy(instBullet, 1f);
    }
}