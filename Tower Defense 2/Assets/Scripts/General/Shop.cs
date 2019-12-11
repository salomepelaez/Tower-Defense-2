using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
        
    private int basicTurretPrice = 50;
    private int doubleShooterPrice = 100;
    private int laserTurret = 250;

    public TextMeshProUGUI noMoney;

    private void Awake()
    {
        noMoney = GameObject.Find("InsufficientMoney").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        buildManager = BuildManager.instance;
        ShopManager.money = 100;
    }
       
    public void PurchaseBasicTurret()
    {
        if (ShopManager.money >= basicTurretPrice)
        {
            buildManager.SetTurret(buildManager.basicTurret);
            ShopManager.money = ShopManager.money - basicTurretPrice;
        }
        
        else if(ShopManager.money < basicTurretPrice)
        {
            StartCoroutine(InsufficientMoney());
        }        
    }

    public void PurchaseDoubleShooterTurret()
    {
        if (ShopManager.money >= doubleShooterPrice)
        {
            buildManager.SetTurret(buildManager.doubleShooterTurret);
            ShopManager.money = ShopManager.money - doubleShooterPrice;
        }

        else if (ShopManager.money < doubleShooterPrice)
        {
            StartCoroutine(InsufficientMoney());
        }
    }

    public void PurchaseLaserTurret()
    {
        if (ShopManager.money >= laserTurret)
        {
            buildManager.SetTurret(buildManager.laserTurret);
            ShopManager.money = ShopManager.money - laserTurret;
        }

        else if (ShopManager.money < laserTurret)
        {
            StartCoroutine(InsufficientMoney());
        }
    }

    IEnumerator InsufficientMoney()
    {
        noMoney.text = "You don't have enough money";

        yield return new WaitForSeconds(2f);

        noMoney.text = "";
    }
}
