using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damageAmount = 10f;       // Schade per aanval
    public float attackCooldown = 2f;      // Tijd tussen aanvallen
    private float lastAttackTime;          // Tijd sinds laatste aanval

    private BaseHealth baseHealth;       // Referentie Health script base
    
    void Update()
    {
        if (baseHealth != null && Time.time >= lastAttackTime + attackCooldown)
        {
            baseHealth.TakeDamage(damageAmount);
            lastAttackTime = Time.time; 
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Base")) 
            // Zorg dat de base de tag "Base" heeft
        {
            baseHealth = collision.gameObject.GetComponent<BaseHealth>();
        }
    }
    
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            baseHealth = null; 
            // Verwijdert de referentie wanneer de vijand de base verlaat
        }
    }
}

