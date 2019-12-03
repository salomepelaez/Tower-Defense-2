using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public Color color1;
    private Renderer rend;
    private GameObject turret;

    BuildManager buildManager;


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
        /*if (buildManager.GetTurretToBuild() == null)
            return;*/

        if (turret != null)
        {
            Debug.Log("no xd");
            return;
        }

        Vector3 pos = new Vector3(transform.position.x, 0.5f, transform.position.z);
        GameObject iTurret = BuildManager.instance.GetTurretToBuild();
        turret = Instantiate(iTurret, pos, transform.rotation);
    }
}
