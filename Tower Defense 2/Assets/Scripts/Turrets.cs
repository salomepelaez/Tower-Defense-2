using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    private float range = 5f;
    public Transform target;
    public Transform partToRotate;
    public GameObject bullet;

    private float bulletSpeed = 100f;

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
            StartCoroutine("Shoot");
        }

        else
            target = null;
    }

    IEnumerator Shoot()
    {
        GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        instBullet.AddComponent<Rigidbody>();
        Rigidbody rigidbody = instBullet.GetComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.up * bulletSpeed);

        yield return new WaitForSeconds(2f);

        Destroy(instBullet, 1f);        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
