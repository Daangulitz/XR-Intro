using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRrigpositionongamestart : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager
    public Vector3 startPosition;   // Position when gameActive = true
    public Vector3 resetPosition;  // Position when gameActive = false
    private bool isAtStartPosition = false; // Track whether the position has been set for the current state

    void Start()
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>(); // Find GameManager in the scene if not assigned
        }
    }

    void Update()
    {
        if (gameManager != null)
        {
            // When gameActive is true, move to startPosition (only once)
            if (gameManager.gameActive && !isAtStartPosition)
            {
                transform.position = startPosition;
                isAtStartPosition = true;
                Debug.Log("Moved to Start Position");
            }
            // When gameActive is false, move to resetPosition (only once)
            else if (!gameManager.gameActive && isAtStartPosition)
            {
                transform.position = resetPosition;
                isAtStartPosition = false;
                Debug.Log("Moved to Reset Position");
            }
        }
    }
}