﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : Enemy
{
    void Start()
    {
        target = EnemyBehaviour.points[0];
        life = 2;
        speed = 2f;
    }

}