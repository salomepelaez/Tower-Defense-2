using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseBasicTurret()
    {
        Debug.Log("buñuelo");
        buildManager.SetTurret(buildManager.basicTurret);
    }

    public void PurchaseDoubleShooterTurret()
    {
        Debug.Log("macaco");
        buildManager.SetTurret(buildManager.doubleShooterTurret);
    }

    public void PurchaseLaserTurret()
    {
        Debug.Log("piu");
        buildManager.SetTurret(buildManager.laserTurret);
    }
}
