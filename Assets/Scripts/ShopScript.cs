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

    public void PurchaseTurret()
    {
        Debug.Log("purchased turret");
        buildManager.SetTurretToBuild(buildManager.ArrowTower);

    }
    public void PurchaseOttaTurret()
    {
        Debug.Log("purchased otta turret");
        buildManager.SetTurretToBuild(buildManager.BombTower);

    }

}
