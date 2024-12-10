using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilUI : MonoBehaviour
{
    public string prefabTag = "Enemy"; // Ensure the prefab has this tag
    [SerializeField] private Health healthScript;
    public PlayerController playerMovement;

    private bool moveUp = false;
    private bool moveDown = false;
    private bool moveLeft = false;
    private bool moveRight = false;

    void Update()
    {
        // Automatically find the health script from the tagged prefab
        if (healthScript == null)
        {
            Debug.Log("No health script");
            GameObject spawnedPrefab = GameObject.FindWithTag(prefabTag);
            if (spawnedPrefab != null)
            {
                healthScript = spawnedPrefab.GetComponent<Health>();
                if (playerMovement == null)
                {
                    Debug.Log("No player movement script");
                    playerMovement = GameObject.FindWithTag(prefabTag).GetComponentInParent<PlayerController>();
                }
            }
        }

        // Handle movement based on input flags
        if (playerMovement != null)
        {
            Vector3 movement = Vector3.zero;

            if (moveUp) movement += Vector3.forward;
            if (moveDown) movement += Vector3.back;
            if (moveLeft) movement += Vector3.left;
            if (moveRight) movement += Vector3.right;
        }
    }

    // PointerDown and PointerUp methods for each direction
    public void OnMoveUpPointerDown() => moveUp = true;
    public void OnMoveUpPointerUp() => moveUp = false;

    public void OnMoveDownPointerDown() => moveDown = true;
    public void OnMoveDownPointerUp() => moveDown = false;

    public void OnMoveLeftPointerDown() => moveLeft = true;
    public void OnMoveLeftPointerUp() => moveLeft = false;

    public void OnMoveRightPointerDown() => moveRight = true;
    public void OnMoveRightPointerUp() => moveRight = false;

    // Damage and Heal buttons
    public void DamageButton()
    {
        if (healthScript != null)
        {
            healthScript.TakeDamage(10); // Decreases health by 10
        }
        Debug.Log("Health script damaged.");
    }

    public void HealButton()
    {
        if (healthScript != null)
        {
            healthScript.RestoreHealth(10); // Restores health by 10
        }
        Debug.Log("Health script restored.");
    }
}
