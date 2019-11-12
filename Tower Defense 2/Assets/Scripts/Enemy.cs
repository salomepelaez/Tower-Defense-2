using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject enemy;

    private void Start()
    {
        InvokeRepeating("Create", 1f, 3f);
    }

    void Create()
    {
        enemy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        enemy.GetComponent<Renderer>().material.color = Color.cyan;
        Vector3 pos = new Vector3();
        pos.x = 12.13f;
        pos.y = 0.46f;
        pos.z = 11.87f;
        enemy.transform.position = pos;
        
        enemy.AddComponent<EnemyMove>();
    }

}
