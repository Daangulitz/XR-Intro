using UnityEngine;

public class TowerGrenade : MonoBehaviour
{
    public GameObject towerPrefab;
    public GameObject towerGrenadePrefab;
    public Transform[] spawnPoints;  
    
    void OnCollisionEnter(Collision collision)
    {
        // Check if the grenade hits the terrain
        if (collision.gameObject.CompareTag("Terrain"))
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            Invoke(nameof(SpawnNewTowerGrenade), 0.1f); // Delay the spawn by 0.1 seconds
            Destroy(gameObject,0.1f);
        }
    }
    
    void SpawnNewTowerGrenade()
    {
        if (spawnPoints.Length == 0) return;

        int randomIndex = Random.Range(0, spawnPoints.Length);

        // Instantiate the bomb prefab at the chosen spawn point
        Instantiate(towerGrenadePrefab, spawnPoints[randomIndex].position, spawnPoints[randomIndex].rotation);
    }
}