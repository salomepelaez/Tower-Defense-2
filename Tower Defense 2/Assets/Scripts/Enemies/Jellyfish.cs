using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : Enemy
{
    // Se asignaron las variables propias del enemigo
    void Start()
    {
        target = EnemyBehaviour.points[0];
        life = 3;
        speed = 2f;
    }

}