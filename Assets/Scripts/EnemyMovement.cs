using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavePointIndex = 0;

    private Enemy E;

    private void Start()
    {
        E = GetComponent<Enemy>();
        target = WaypointScript.points[0];
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * E.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
    }
    void GetNextWayPoint()
    {
        if (wavePointIndex >= WaypointScript.points.Length - 1)
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
