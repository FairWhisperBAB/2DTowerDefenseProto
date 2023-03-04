using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTower", menuName = "Towers")]
public class Towers : ScriptableObject
{
    [SerializeField] public GameObject turretPrefab;

    [Header("INFO")]
    [SerializeField] private string _name;
    [SerializeField] private int _cost;
    [TextArea] [SerializeField] private string _description;

    [Header("STATS")]
    [SerializeField] private int _damage;
    //Add stats here

    public string Name => _name;
    public int Cost => _cost;
    public string Description => _description;

    public int Damage => _damage;


}
