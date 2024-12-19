using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TowerGrenade : MonoBehaviour
{
    public GameObject towerPrefab;
    public GameObject towerGrenadePrefab;
    public Transform[] spawnPoints;
    public GameManager gameManager;
    public Vector3 ResetGrenadePosition;
    private XRGrabInteractable grabInteractable; // Reference to the XR Grab component


    private bool _isPickedUp; // Tracks whether the grenade is picked up

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
            grabInteractable.selectEntered.AddListener(onTowerPickedUp); 
            grabInteractable.selectEntered.RemoveListener(dissabletowerpickedup);
        }
    }

    private void OnDisable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(onTowerPickedUp);
            grabInteractable.selectEntered.AddListener(dissabletowerpickedup); 
        }
    }

    private void onTowerPickedUp(SelectEnterEventArgs args)
    {
        _isPickedUp = true;
    }

    private void dissabletowerpickedup(SelectEnterEventArgs args)
    {
        _isPickedUp = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (!_isPickedUp) return;
        
        if (gameManager.currentCoins >= 10)
        {
            if (collision.gameObject.CompareTag("Terrain"))
            {
                gameManager.currentCoins -= 10;
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                SpawnNewTowerGrenade();
                Destroy(gameObject, 0.1f);
            }
            else
            {
                transform.position = ResetGrenadePosition;
            }
        }
        else
        {
            transform.position = ResetGrenadePosition;
        }
    }

    void SpawnNewTowerGrenade()
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        if (spawnPoint != null)
        {
            Instantiate(towerGrenadePrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}