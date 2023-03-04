using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    private GameObject turret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    private void OnMouseDown()
    {
        if (buildManager.GetTurretToBuild() == null) 
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("cant build here");
            return;
        }

        //Build turret
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position, transform.rotation);

    }


    //TAKE OUT WHEN PORTING TO MOBILE
    public Color hovercolor;

    public void OnMouseEnter()
    {
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        GetComponent<Renderer>().material.color = hovercolor;
    }
    public void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

}
