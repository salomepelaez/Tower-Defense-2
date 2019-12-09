using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static int systemLife;
    public static bool inGame = true;

    private void Start()
    {
        systemLife = 100;
    }

    private void Update()
    {
        if (systemLife <= 0)
        {
            inGame = false;
            Debug.Log("gei over");
        }
    }
}
