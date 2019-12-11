using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSBullet : MonoBehaviour
{
    public static int damage = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
