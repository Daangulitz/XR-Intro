using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 50f;
    private Transform Target;
    
    private Health health;

    public void SetTarget(Transform newTarget)
    {
        Target = newTarget;
    }

    void Update()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = (Target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, Target.position) < 0.2f)
        {
            Explode();
        }
    }

    void Explode()
    {
        Target.GetComponent<Health>().TakeDamage(damage);
        
        Destroy(gameObject, 0.1f);
    }
}