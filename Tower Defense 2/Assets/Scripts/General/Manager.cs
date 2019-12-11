using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public static int systemLife;
    public static bool inGame = true;
    public static int counter;

    public TextMeshProUGUI gameOver;

    private void Start()
    {
        systemLife = 100;
        counter = 0;
    }

    private void Update()
    {
        if (systemLife <= 0)
        {
            inGame = false;
            gameOver.text = "Gameover";
            Debug.Log("gei mover");
        }

        if(counter >= 50)
        {
            inGame = false;
            Debug.Log("yeiii");
        }
    }
}
