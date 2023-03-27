using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName ="EnemySO")]
public class EnemySO : ScriptableObject
{
    [SerializeField] public GameObject enemyPrefab;

    [Header("Stats")]
    [SerializeField] private int _health;
    [SerializeField] private int _speed;
    [SerializeField] private int _moneyGained;


    public int Health => _health;
    public int Speed => _speed;
    public int MoneyGained => _moneyGained;


}
