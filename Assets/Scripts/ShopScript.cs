using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseArcherTurret()
    {
        Debug.Log("purchased Archer turret");
        buildManager.SetTurretToBuild(buildManager.ArrowTower);

    }
    public void PurchaseBombTurret()
    {
        Debug.Log("purchased Bomb turret");
        buildManager.SetTurretToBuild(buildManager.BombTower);

    }

    public void PurchaseMageTurret()
    {
        Debug.Log("purchased Mage turret");
        buildManager.SetTurretToBuild(buildManager.MageTower);

    }

}
