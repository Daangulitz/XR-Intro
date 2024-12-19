using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class BaseUpgrade : MonoBehaviour
{
    public BaseHealth baseHealth;
    public GameManager gameManager;

    private XRGrabInteractable grabInteractable;

    private Vector3 BasePosition; 

    private void Awake()
    {

        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable == null)
        {
            Debug.LogError("No XRGrabInteractable component found on the base health upgrade!");
        }


        BasePosition = transform.position;
    }

    private void OnEnable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnHealthPickup); 
            grabInteractable.selectExited.AddListener(OnRelease); 
        }
    }

    private void OnDisable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnHealthPickup);
            grabInteractable.selectExited.RemoveListener(OnRelease);
        }
    }

    private void OnHealthPickup(SelectEnterEventArgs args)
    {
        if (gameManager != null)
        {
            if (gameManager.currentCoins >= 10f && baseHealth != null)
            {
                baseHealth.currentHealth += 20f;
                gameManager.currentCoins -= 10f;
            }
            else
            {
                Debug.LogError("Not Enough Money!");
            }
        }
        else
        {
            Debug.LogError("No Game Manager!");
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        transform.position = BasePosition;
    }
}
