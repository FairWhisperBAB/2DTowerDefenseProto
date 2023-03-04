using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one Build Manager in scene");
            return;
        }
        instance = this;
    }

    public Towers towertype;

    private void Start()
    {
        turretToBuild = towertype.turretPrefab;
    }

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild() 
    { 
        return turretToBuild;
    }

}
