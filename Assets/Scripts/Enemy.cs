using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private EnemySO enemyType;
    [SerializeField] private BulletSO bulletType;

    [SerializeField] private int health;

    [HideInInspector]
    public float startSpeed;

    public float speed;


    private void Start()
    {
        health = enemyType.Health;
        speed = enemyType.Speed;
        startSpeed = speed;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
        
        Slow(bulletType.Slowing);
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
        StartCoroutine("ResetSpeed");
    }

    void Die()
    {
        GameStats.Money += enemyType.MoneyGained;
        Destroy(gameObject);
    }

    IEnumerator ResetSpeed()
    {
        yield return new WaitForSeconds(3f);
        speed = startSpeed;
    }

}
