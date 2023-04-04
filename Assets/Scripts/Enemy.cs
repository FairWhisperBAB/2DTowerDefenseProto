using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private EnemySO enemyType;

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
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
        StartCoroutine("ResetSpeed");
    }

    IEnumerator ResetSpeed()
    {
        yield return new WaitForSeconds(3f);
        speed = startSpeed;
    }

    void Die()
    {
        GameStats.Money += enemyType.MoneyGained;
        Destroy(gameObject);
    }
}
