using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    private GameObject turret;

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("cant build here");
            return;
        }

        //Build turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position, transform.rotation);

    }

    public Color hovercolor;

    public void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = hovercolor;
    }
    public void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

}
