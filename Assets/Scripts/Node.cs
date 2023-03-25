using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [Header("Optional")]
    public GameObject turret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    private void OnMouseDown()
    {
        if (!buildManager.CanBuild) 
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("cant build here");
            return;
        }

        buildManager.BuildTurretOn(this);
    }


    //TAKE OUT WHEN PORTING TO MOBILE
    public Color hovercolor;

    public void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
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
