using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShooterTurret : MonoBehaviour
{
    private float range = 2.5f;
    public Transform target;
    public Transform partToRotate;

    private void Start()
    {
        InvokeRepeating("GetTarget", 0f, 2f);
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
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
