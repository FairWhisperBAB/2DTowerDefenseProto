using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class Node : MonoBehaviour
{
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TowerSO towerType;
    [HideInInspector]
    public bool isUpgraded = false;

    [SerializeField] private TowerSO UpgradedArcher;
    [SerializeField] private TowerSO UpgradedBomb;
    [SerializeField] private TowerSO UpgradedMage;

    [SerializeField] Vector3 positionOffset;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
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

    void BuildTurret(TowerSO tower)
    {
        if (GameStats.Money < tower.Cost)
        {
            Debug.Log("Not enough money to build " + tower);
            return;
        }
        GameStats.Money -= tower.Cost;

        GameObject _turret = Instantiate(tower.turretPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        towerType = tower;

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

        if (turret.CompareTag("Archer"))
        {
            GameObject _turret = Instantiate(UpgradedArcher.turretPrefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;
        }
        else if (turret.CompareTag("Bomb"))
        {
            GameObject _turret = Instantiate(UpgradedBomb.turretPrefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;
        }
        else if (turret.CompareTag("Mage"))
        {
            GameObject _turret = Instantiate(UpgradedMage.turretPrefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;
        }

        isUpgraded = true;

        Debug.Log("turret Upgraded!");
    }

    public void SellTurret()
    {
        GameStats.Money += towerType.GetSellAmount();

        Destroy(turret);
        towerType = null;
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
