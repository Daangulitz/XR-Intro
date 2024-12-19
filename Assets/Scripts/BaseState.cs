using UnityEngine;

public class BaseState : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private BaseHealth baseHealth;

    private void Update() {
        if (gameManager.gameActive)
        {
            if (baseHealth == null)
            {
                baseHealth.GetComponent<BaseHealth>();
            }

            if (baseHealth != null)
            {
                if (gameManager != null)
                {
                    if (baseHealth.currentHealth <= 0)
                    {
                        Debug.Log("Game Over");
                        gameManager.GameOver();
                        Destroy(gameObject);
                    }
                }
                else
                {
                    Debug.LogError("Base has no reference to GameManager");
                }

            }
            else
            {
                Debug.LogError("Base has no reference to Health");
            }
        }
    }
}