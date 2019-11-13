using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    private Vector3 direction;
    private float range = 5f;
    public Transform target;

    void Update()
    {
        GetTarget();
    }

    public void GetTarget()
    {
        EnemyMove closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (var e in FindObjectsOfType<EnemyMove>())
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
