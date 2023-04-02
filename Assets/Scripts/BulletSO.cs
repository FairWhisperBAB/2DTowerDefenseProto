using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBullet", menuName = "BulletSO")]

public class BulletSO : ScriptableObject
{
    [SerializeField] public GameObject bulletPrefab;


    [Header("Stats")]
    [SerializeField] private int _speed;
    [SerializeField] private int _aoe;
    [SerializeField] private float _slowing;


    public int Speed => _speed;

    public int AOE => _aoe;
    public float Slowing => _slowing;


}
