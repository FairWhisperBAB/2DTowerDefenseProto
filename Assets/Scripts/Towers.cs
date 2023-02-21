using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTower", menuName = "Towers")]
public class Towers : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _cost;
    [TextArea] [SerializeField] private string _description;

    public string Name => _name;
    public int Cost => _cost;
    public string Description => _description;


}
