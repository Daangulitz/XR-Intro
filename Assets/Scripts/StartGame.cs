using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StartGame : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager

    private XRGrabInteractable grabInteractable; // Reference to the XR Grab component
    

    private void Awake()
    {
        // Ensure the weapon has an XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable == null)
        {
            Debug.LogError("No XRGrabInteractable component found on the weapon!");
        }
    }

    private void OnEnable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnWeaponPickedUp); // Listen for grab event
        }
    }

    private void OnDisable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnWeaponPickedUp);
        }
    }

    private void OnWeaponPickedUp(SelectEnterEventArgs args)
    {
        // Set gameActive in the GameManager to true when weapon is picked up
        if (gameManager != null)
        {
            gameManager.gameActive = true;
            Debug.Log("Game started! Weapon picked up.");
        }
        else
        {
            gameManager.gameActive = false;
            Debug.LogError("GameManager reference is missing!");
        }
    }
    
}
