using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : Enemy
{
    void Start()
    {
        target = EnemyBehaviour.points[0];
        life = 5;
        speed = 0.5f;
    }
    
}
