using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;  
    public float spawnInterval = 5f;     
    private float lastSpawnTime;         
    private int lastSpawnedIndex = -1;  

    void Update()
    {
        if (Time.time >= lastSpawnTime + spawnInterval)
        {
            SpawnObject();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnObject()
    {
        if (objectsToSpawn != null && objectsToSpawn.Length > 0)
        {
            int randomIndex;
            
            do
            {
                randomIndex = Random.Range(0, objectsToSpawn.Length);
            } while (randomIndex == lastSpawnedIndex);

            lastSpawnedIndex = randomIndex;


            GameObject objectToSpawn = objectsToSpawn[randomIndex];
            Instantiate(objectToSpawn, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogWarning("Objects to spawn array is empty or not set.");
        }
    }
}