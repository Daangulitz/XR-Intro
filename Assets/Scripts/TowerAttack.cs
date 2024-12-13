using UnityEngine;
using System.Collections.Generic;

public class TowerAttack : MonoBehaviour
{
    public float fireRate = 1f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    private float nextFireTime = 0f;
    private List<Transform> enemiesInRange = new List<Transform>();
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInRange.Add(other.transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(other.transform);
        }
    }
    
    Transform GetClosestEnemy()
    {
        Transform closestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        // Create a temporary list to store null references
        List<Transform> nullEnemies = new List<Transform>();

        foreach (Transform enemy in enemiesInRange)
        {
            if (enemy != null)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    closestEnemy = enemy;
                }
            }
            else
            {
                // Add null enemy to the temporary list
                nullEnemies.Add(enemy);
            }
        }

        // Remove all null references from the main list
        foreach (var nullEnemy in nullEnemies)
        {
            enemiesInRange.Remove(nullEnemy);
        }

        return closestEnemy;
    }

    
    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Transform Target = GetClosestEnemy();
            if (Target != null)
            {
                Shoot(Target);
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    void Shoot(Transform Target)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().SetTarget(Target);
    }
}
