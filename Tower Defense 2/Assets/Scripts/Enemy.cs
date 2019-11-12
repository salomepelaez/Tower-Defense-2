using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    GameObject enemy;

    private void Start()
    {
        InvokeRepeating("Create", 1f, 3f);
    }

    void Create()
    {
        enemy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Vector3 pos = new Vector3();
        pos.x = 11.93f;
        pos.y = 1.07f;
        pos.z = 11.54f;

        enemy.AddComponent<EnemyMove>();
    }
}
