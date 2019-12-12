using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public static int systemLife;
    public static int counter;

    public static bool inGame = true;
    public static bool winner;

    public TextMeshProUGUI gameOver;

    public AudioSource music;

    private void Start()
    {
        systemLife = 100;
        counter = 0;
        music.Play();
    }

    private void Update()
    {
        if (systemLife <= 0)
        {
            inGame = false;
            gameOver.text = "Gameover";
            music.Stop();
        }

        if(counter >= 50)
        {
            inGame = false;
            winner = true;
            music.Stop();
        }
    }
}
