using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TowerSO towerType;
    [HideInInspector]
    public TowerSO upgradedTowerType;
    [HideInInspector]
    public bool isUpgraded = false;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {

            buildManager.SelectNode(this);
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TowerSO towerType)
    {
        if (GameStats.Money < towerType.Cost)
        {
            Debug.Log("Not enough money to build " + towerType);
            return;
        }
        GameStats.Money -= towerType.Cost;

        GameObject _turret = Instantiate(towerType.turretPrefab, transform.position, Quaternion.identity);
        turret = _turret;

        Debug.Log("turret built!");
    }

    public void UpgradeTurret()
    {
        if (GameStats.Money < towerType.UpgradeCost)
        {
            Debug.Log("Not enough money to Upgrade " + towerType);
            return;
        }
        GameStats.Money -= towerType.UpgradeCost;

        Destroy(turret);

        GameObject _turret = Instantiate(upgradedTowerType.turretPrefab, transform.position, Quaternion.identity);
        turret = _turret;

        isUpgraded = true;

        Debug.Log("turret Upgraded!");
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
