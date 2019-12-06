using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Nodes : MonoBehaviour
{
    public Color color1;
    private Renderer rend;
    private GameObject turret;

    BuildManager buildManager;

    public TextMeshProUGUI cannotBuildThere;
    public TextMeshProUGUI noTurretSelected;
    
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
            StartCoroutine(CannotBuild());
            return;
        }

        if(BuildManager.instance.GetTurretToBuild() == null)
        {
            StartCoroutine(NoTurret());
            return;
        }

        Vector3 pos = new Vector3(transform.position.x, 0.5f, transform.position.z);
        GameObject iTurret = BuildManager.instance.GetTurretToBuild();
        turret = Instantiate(iTurret, pos, transform.rotation);
        BuildManager.instance.SetTurret(null);
    }

    IEnumerator CannotBuild()
    {
        cannotBuildThere.text = "You can't build there!";

        yield return new WaitForSeconds(2f);

        cannotBuildThere.text = "";
    }

    IEnumerator NoTurret()
    {
        noTurretSelected.text = "Select a turret!";

        yield return new WaitForSeconds(2f);

        noTurretSelected.text = "";
    }
}
