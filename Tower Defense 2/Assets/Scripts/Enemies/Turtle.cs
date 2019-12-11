using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : Enemy
{
    void Start()
    {
        target = EnemyBehaviour.points[0];
        life = 10;
        speed = 0.1f;
    }

}
