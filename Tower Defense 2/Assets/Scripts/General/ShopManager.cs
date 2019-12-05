using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public TextMeshProUGUI moneyCounter;

    public static int money;
       
    private void Update()
    {
        moneyCounter.text = "= " + money;
    }
}
