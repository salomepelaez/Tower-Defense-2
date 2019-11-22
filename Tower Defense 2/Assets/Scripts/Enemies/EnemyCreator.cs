using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    GameObject enemy;
    
    private void Start()
    {
        InvokeRepeating("Create", 1f, 3f);
    }

    void Create()
    {
        enemy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        enemy.transform.tag = "Enemy";
        enemy.GetComponent<Renderer>().material.color = Color.cyan;
        enemy.AddComponent<SphereCollider>();
        enemy.GetComponent<SphereCollider>().isTrigger = true;
        Vector3 pos = new Vector3();
        pos.x = 12.13f;
        pos.y = 0.46f;
        pos.z = 11.87f;
        enemy.transform.position = pos;

        enemy.AddComponent<Enemy>();
    }
}
