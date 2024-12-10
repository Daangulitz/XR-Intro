using UnityEngine.AI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private NavMeshAgent agent;
    private Transform playerTransform;

    void Start()
    {
        // Vind de NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();

        // Zoek de XR Rig met de tag "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        // Beweeg naar de positie van de speler als deze is gevonden
        if (playerTransform != null)
        {
            agent.SetDestination(playerTransform.position);
        }
    }
}

