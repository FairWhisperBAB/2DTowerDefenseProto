using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class NodeUI : MonoBehaviour
{
    public GameObject UI;

    private Node target;

    [SerializeField] private TextMeshProUGUI sellAmount;
    [SerializeField] private TextMeshProUGUI upgradeCost;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.towerType.UpgradeCost;
        }
        else
        {
            upgradeCost.text = "DONE";
        }

        sellAmount.text = "$" + target.towerType.GetSellAmount();

        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        Debug.Log("is being pushed");

        target.UpgradeTurret();

        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
