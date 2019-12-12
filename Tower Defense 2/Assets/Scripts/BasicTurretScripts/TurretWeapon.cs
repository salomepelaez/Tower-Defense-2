using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretWeapon : MonoBehaviour
{
    //A continuación se crearon las variables que se utilizarán en el código.
    public GameObject bullet;

    private float bulletSpeed = 800f;
    private float range = 3f;

    public Transform target;

    private Vector3 _direction;

    public AudioSource shot;

    private void Start()
    {
        //Decidí llamar la función en un Invoke y no en el Update para controlar la velocidad con la que se escoge el target. 
        InvokeRepeating("GetTarget", 0f, 1f); 
    }

    // La siguiente función es la encargada de recibir la información de los objetos cercanos e identificarlos o no como enemigos.
    public void GetTarget()
    {
        Enemy closest = null; //En este caso, toma como referencia a los objetos que sean del tipo Enemy.
        float closestDistance = Mathf.Infinity;

        foreach (var e in FindObjectsOfType<Enemy>())
        {
            float distance = Vector3.Distance(e.transform.position, transform.position); // Este flotante mide la distancia entre la torreta y el enemigo.

            if (distance < closestDistance) 
            {
                closestDistance = distance;
                closest = e;
            }
        }

        // Si la distancia es menor al rango, el objeto más cercano pasa a ser el nuevo target y disparar.
        if (closest != null && closestDistance < range)
        {
            target = closest.transform;
            Shoot();
        }

        else
            target = null;
    }


    // Este void se encarga de instanciar la bala, mediante un prefab y añadirle fuerza.
    void Shoot()
    {
        GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        Rigidbody rigidbody = instBullet.GetComponent<Rigidbody>();
        _direction = Vector3.Normalize(target.transform.position - transform.position);
        rigidbody.AddForce(_direction * bulletSpeed);

        shot.Play();

        Destroy(instBullet, 1f);
    }
}
