using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    BuildManager buildManager;

    [Header("TOWER TYPES")]
    [SerializeField] private TowerSO ArrowTower;
    [SerializeField] private TowerSO BombTower;
    [SerializeField] private TowerSO MageTower;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectArcherTurret()
    {
        Debug.Log("purchased Archer turret");
        buildManager.SelectTurretToBuild(ArrowTower);

    }
    public void SelectBombTurret()
    {
        Debug.Log("purchased Bomb turret");
        buildManager.SelectTurretToBuild(BombTower);

    }

    public void SelectMageTurret()
    {
        Debug.Log("purchased Mage turret");
        buildManager.SelectTurretToBuild(MageTower);

    }

}
