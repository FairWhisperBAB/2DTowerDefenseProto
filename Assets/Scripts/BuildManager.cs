using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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


    [Header("other")]
    private TowerSO turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
        if (GameStats.Money < turretToBuild.Cost) 
        {
            Debug.Log("Not enough money to build " + turretToBuild);
            return;
        }

        GameStats.Money -= turretToBuild.Cost;

        GameObject turret = Instantiate(turretToBuild.turretPrefab, node.transform.position, Quaternion.identity);
        node.turret = turret;

        Debug.Log("turret built! Money remaining: " + GameStats.Money);
    }
    public void SelectTurretToBuild(TowerSO towerType)
    {
        turretToBuild = towerType;
    }
}
