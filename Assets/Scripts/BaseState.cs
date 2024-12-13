using UnityEngine;

public class BaseState : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Health health;

    private void Update() {
        if (health == null)
        {
            health.GetComponent<Health>();
        } 
        if (health != null)
        {
            if(gameManager != null)
            {
                if(health.currentHealth <= 0)
                {
                    Debug.Log("Game Over");
                    gameManager.GameOver();
                    Destroy(gameObject);
                }
            } else
            {
                Debug.LogError("Base has no reference to GameManager");
            }
            
        } else 
        {
            Debug.LogError("Base has no reference to Health");
        }
    }
}