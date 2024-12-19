using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wapeondamage : MonoBehaviour
{
    public float damageAmount = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object collided with has the correct tag
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Try to access a Health component on the target
            Health targetHealth = collision.gameObject.GetComponent<Health>();

            if (targetHealth != null)
            {
                // Deal damage to the target
                targetHealth.TakeDamage(damageAmount);
                Debug.Log($"Dealt {damageAmount} damage to {collision.gameObject.name}");
            }
            else
            {
                Debug.LogWarning($"The target {collision.gameObject.name} does not have a Health component!");
            }
        }
    }
}
