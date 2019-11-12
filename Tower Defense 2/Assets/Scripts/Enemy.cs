﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;
    float speed = 10f;
    Vector3 direction;
    int index = 0;

    void Start()
    {
        target = EnemyBehaviour.points[0];
    }

    void Update()
    {
        direction = Vector3.Normalize(target.transform.position - transform.position);
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(target.transform.position - transform.position) <= 0.2f)
        {
            GetNext();
            return;
        }
    }

    void GetNext()
    {
        index++;
        target = EnemyBehaviour.points[index];
    }
}
