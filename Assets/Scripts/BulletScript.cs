using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Transform target;

    [Header("Scriptable Objects")]
    [SerializeField] private TowerSO TowerType;
    [SerializeField] private BulletSO bulletType;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = bulletType.Speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget(target);
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget(Transform enemy)
    {
        if (bulletType.AOE > 0f)
        {
            Explode();
        }
        else if (bulletType.Slowing > 0f)
        {
            if (enemy.TryGetComponent<Enemy>(out var e))
            {
                e.Slow(bulletType.Slowing);
                Damage(target);
            }
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, bulletType.AOE);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        if (enemy.TryGetComponent<Enemy>(out var e)) 
        {
            e.TakeDamage(TowerType.Damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, bulletType.AOE);
    }
}
