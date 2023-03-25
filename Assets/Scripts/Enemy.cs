using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 10f;

    private Transform target;
    private int wavePointIndex = 0;

    //ADD INTO SCIRPTABLE OBJECT WHEN MADE
    public int health = 100;
    public int moneyGain = 50;

    private void Start()
    {
        target = WaypointScript.points[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0) 
        {
            Die();
        }
    }

    void Die()
    {
        GameStats.Money += moneyGain;
        Destroy(gameObject);
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if(wavePointIndex >= WaypointScript.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavePointIndex++;
        target = WaypointScript.points[wavePointIndex];
    }

    void EndPath()
    {
        GameStats.Lives--;
        Destroy(gameObject);
        
    }

}
