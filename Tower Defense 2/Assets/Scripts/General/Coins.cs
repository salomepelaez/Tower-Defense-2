using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private int coinValue = 25;

    private void OnMouseDown()
    {
        ShopManager.money = ShopManager.money + coinValue;

        Destroy(gameObject);
    }
}
