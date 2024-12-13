using UnityEngine;
using UnityEngine.AI;

public class ExplodeOnImpact : MonoBehaviour
{
    public float explosionForce = 500f;      // Kracht van de explosie
    public float explosionRadius = 5f;       // Radius van de explosie
    public float explosionDamage = 50f;

    [SerializeField] private ParticleSystem ExplodeFX;
    [SerializeField] private AudioSource ExplodeSound;
    
    public GameObject bombPrefab;            // Bomb prefab to spawn
    public Transform[] spawnPoints;          // Array of spawn points

    private Health _enemyHealth;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Zorg dat vijanden de tag "Enemy" hebben
        {
            ExplodeFX.Play();
            ExplodeSound.Play();
            Explode();

            SpawnNewBomb(); // Spawn a new bomb after explosion

            Destroy(gameObject, 1f); // Verwijder het object na de explosie
        }
    }

    void Explode()
    {
        // Vind alle objecten in de buurt van de explosie
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Health healthScript = nearbyObject.GetComponent<Health>();
            if (healthScript != null)
            {
                healthScript.TakeDamage(explosionDamage);
            }
						
            // Add explosion force
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    }

    void SpawnNewBomb()
    {
        if (spawnPoints.Length == 0) return; // Safety check

        // Kies een willekeurige spawnpunt
        int randomIndex = Random.Range(0, spawnPoints.Length);

        // Instantiate the bomb prefab at the chosen spawn point
        Instantiate(bombPrefab, spawnPoints[randomIndex].position, spawnPoints[randomIndex].rotation);
    }
}
