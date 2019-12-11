using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    
    Vector3 direction;

    public GameObject instCoin;

    private int index = 0;
    public int life;
    private int enemyDamage = 10;
    public float speed;

    void Update()
    {
        if (Manager.inGame == true)
        {
            direction = Vector3.Normalize(target.transform.position - transform.position);
            transform.position += direction * speed * Time.deltaTime;

            if (Vector3.Distance(target.transform.position, transform.position) <= 0.2f)
            {
                GetNext();
            }
        }
    }

    void GetNext()
    {
        index++;
        target = EnemyBehaviour.points[index];

        if (index >= EnemyBehaviour.points.Length - 1)
        {
            Destroy(gameObject);
            Manager.systemLife = Manager.systemLife - enemyDamage;
            Debug.Log(Manager.systemLife);
        }
    }

   public void OnTriggerEnter(Collider other)
   {
        if (other.transform.tag == "Bullet")
        {
            life = life - TurretBullet.damage;

            if (life < 0)
            {
                Destroy(gameObject, 0.2f);
                Manager.counter = Manager.counter + 1;
                GameObject coin = Instantiate(instCoin, transform.position, transform.rotation);                               
            }
        }

        if (other.transform.tag == "DSBullet")
        {
            life = life - DSBullet.damage;

            if (life < 0)
            {
                Destroy(gameObject, 0.2f);
                Manager.counter = Manager.counter + 1;
                GameObject coin = Instantiate(instCoin, transform.position, transform.rotation);
            }
        }

        if (other.transform.tag == "LaserBullet")
        {
            life = life - LaserBullet.damage;

            if (life < 0)
            {
                Destroy(gameObject, 0.2f);
                Manager.counter = Manager.counter + 1;
                GameObject coin = Instantiate(instCoin, transform.position, transform.rotation);
            }
        }
    }
}
