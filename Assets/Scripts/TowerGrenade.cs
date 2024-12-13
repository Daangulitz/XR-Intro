using UnityEngine;

public class TowerGrenade : MonoBehaviour
{
    public GameObject towerPrefab;
    
    public GameObject towerGrenadePrefab;
    public Transform[] spawnPoints;          // Array of spawn points
    void OnCollisionEnter(Collision collision)
    {
        // Controleer of de grenade het terrein raakt
        if (collision.gameObject.CompareTag("Terrain"))
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            SpawnNewTowerGrenade();
            Destroy(gameObject);
        }
    }
    
    void SpawnNewTowerGrenade()
    {
        if (spawnPoints.Length == 0) return; // Safety check

        // Kies een willekeurige spawnpunt
        int randomIndex = Random.Range(0, spawnPoints.Length);

        // Instantiate the bomb prefab at the chosen spawn point
        Instantiate(towerGrenadePrefab, spawnPoints[randomIndex].position, spawnPoints[randomIndex].rotation);
    }
}