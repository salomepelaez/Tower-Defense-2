using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public Color color1;
    private Renderer rend;
    private GameObject turret;

    private void OnMouseEnter()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = color1;
    }

    private void OnMouseExit()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = Color.white;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("no xd");
            return;
        }

        GameObject iTurret = BuildManager.instance.GetTurretToBuild();
        turret = Instantiate(iTurret, transform.position, transform.rotation);
    }
}
