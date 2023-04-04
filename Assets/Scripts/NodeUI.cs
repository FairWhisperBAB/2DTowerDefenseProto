using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject UI;

    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

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
}
