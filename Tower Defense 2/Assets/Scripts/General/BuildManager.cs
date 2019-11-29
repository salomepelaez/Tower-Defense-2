using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private GameObject turretToBuild;
    public GameObject basicTurret;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        turretToBuild = basicTurret;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
