using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;
    
    Vector3 direction;

    public GameObject instCoin;

    private int index = 0;
    private int life;
    private float speed = 1f;

    void Start()
    {
        target = EnemyBehaviour.points[0];
        life = 3;
    }

    void Update()
    {
        direction = Vector3.Normalize(target.transform.position - transform.position);
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(target.transform.position, transform.position) <= 0.2f)
        {
            GetNext();
        }
    }

    void GetNext()
    {
        index++;
        target = EnemyBehaviour.points[index];

        if (index >= EnemyBehaviour.points.Length - 1)
        {
            Destroy(gameObject);
        }
    }

   public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Bullet")
        {
            life = life - 1;

            if (life <= 0)
            {
                Destroy(gameObject);
                GameObject coin = Instantiate(instCoin, transform.position, transform.rotation);                               
            }
        }
    }
}
