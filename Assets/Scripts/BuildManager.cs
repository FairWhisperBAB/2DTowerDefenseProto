using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public NodeUI nodeUI;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one Build Manager in scene");
            return;
        }
        instance = this;

        Time.timeScale = 1.0f;
    }


    [Header("other")]
    private TowerSO turretToBuild;

    private Node selectedNode;

    public bool CanBuild { get { return turretToBuild != null; } }

    public void SelectNode(Node node)
    {
        if (selectedNode == node) 
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TowerSO towerType)
    {
        turretToBuild = towerType;

        DeselectNode();
    }

    public TowerSO GetTurretToBuild()
    {
            return turretToBuild;
    }
}
