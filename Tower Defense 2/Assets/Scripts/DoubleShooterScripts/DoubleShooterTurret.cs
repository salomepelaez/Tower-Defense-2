using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShooterTurret : MonoBehaviour
{
    // Este código es el que se encarga de hacer una parte específica de la torreta.
    private float range = 5f;

    public Transform target;
    public Transform partToRotate; // Este transform es el que permite escoger la parte a rotar.

    void Update()
    {
        GetTarget();

        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    // De la misma manera que el arma, este método se encarga de escoger un target entre los objetos cercanos.
    // La diferencia está en que no genera una bala, sino que hace rotar la torreta.

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
        }

        else
            target = null;
    }

    // El siguiente bloque de código es solamente para saber el rango de ataque que posee la torreta.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
