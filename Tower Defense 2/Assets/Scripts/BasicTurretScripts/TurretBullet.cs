﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    // Este código genera un daño de ataque, y hace que la bala se destruya si colisiona con un enemigo.
    public static int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
